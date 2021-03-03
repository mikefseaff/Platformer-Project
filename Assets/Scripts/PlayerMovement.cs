using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 25f;
    public bool hasJumpPotion = false;
    public bool hasSpeedPotion = false;
    public int potionModAmount = 0;
    

    public AudioClip jumpClip;
    public AudioClip attackClip;

    private float potionTimeMax = 10f;
    private float potionTimeCur = 0;

    float horizontalMove = 0f;
    bool jumpFlag = false;
    bool jump = false;
    bool attack = false;
    bool canMove = true;

    Vector3 startingPos;
    public GameObject attackProjectile;
    private void Start()
    {
        startingPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (jumpFlag)
        {
            animator.SetBool("IsJumping", true);
            jumpFlag = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (animator.GetBool("IsJumping") == false)
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                jump = true;
                animator.SetBool("IsJumping", true);
            }
            
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        jump = false;
        animator.SetBool("IsAttacking", false);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) /*&& jump == false && jumpFlag == false*/)
        {
            if(animator.GetBool("IsAttacking") == false){
                AudioSource.PlayClipAtPoint(attackClip, transform.position);
                attack = true;
                animator.SetBool("IsAttacking", true);
                canMove = false;
                spawnAttackProjectile();

            }

            
        }
        else if ((Input.GetKey("a") || Input.GetKey("d")))
        {
            animator.SetBool("IsAttacking", false);
        }
        if (hasJumpPotion && potionTimeCur < potionTimeMax)
        {
            controller.m_JumpForceMod = potionModAmount;
            potionTimeCur += Time.fixedDeltaTime;
        }
        else
        {
            potionTimeCur = 0f;
            controller.m_JumpForceMod = 0;
            hasJumpPotion = false;
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpFlag = true;
        }
    }

    void StopAttack()
    {
        attack = false;
        animator.SetBool("IsAttacking", false);
        canMove = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lava")
        {
            this.transform.localPosition = startingPos;
        }
    }

    void spawnAttackProjectile()
    {
        
        if (GetComponent<CharacterController2D>().m_FacingRight)
        {
            GameObject tempAttack = GameObject.Instantiate(attackProjectile, new Vector3(transform.position.x + (GetComponent<SpriteRenderer>().size.x) / 2, transform.position.y, 0), Quaternion.Euler(0, 0, 5));
            tempAttack.GetComponent<Rigidbody2D>().velocity = new Vector3(7, 2, 0);
        }
        else
        {
            GameObject tempAttack = GameObject.Instantiate(attackProjectile, new Vector3(transform.position.x - (GetComponent<SpriteRenderer>().size.x) / 2, transform.position.y, 0), Quaternion.Euler(0, 0, 5));
            tempAttack.GetComponent<Rigidbody2D>().velocity = new Vector3(-7, 2, 0);
        }
        

    }


}
