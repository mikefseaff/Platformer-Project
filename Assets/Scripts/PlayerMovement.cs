using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float decaySpeed1;
    public float decaySpeed2;
    Vector3 startingPos;
    public GameObject attackProjectile;
    private void Start()
    {
        startingPos = this.transform.localPosition;
        decaySpeed1 = 50;
        decaySpeed2 = -50;
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
            if (Input.GetKey("a"))
            {
                decaySpeed2 = -50;
            }
            else if (Input.GetKey("d"))
            {
                decaySpeed1 = 50;
            }
            
            
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
        if (collision.gameObject.tag == "lava" )
        {
           // this.transform.localPosition = startingPos;
           // gameObject.GetComponent<CharacterController2D>().m_Grounded = true;
            //animator.SetBool("IsJumping", false);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if (collision.gameObject.tag == "outOfBounds")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "ice" && GetComponent<CharacterController2D>().m_FacingRight && decaySpeed1 != 0)
        {
            decaySpeed1--;
            Vector3 slide = new Vector3(decaySpeed1, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(slide);
            gameObject.GetComponent<CharacterController2D>().isOnIce = true;
        }
        else if(collision.gameObject.tag == "ice" && !GetComponent<CharacterController2D>().m_FacingRight && decaySpeed2 != 0)
        {
            decaySpeed2++;
            Vector3 slide = new Vector3(decaySpeed2, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(slide);
            gameObject.GetComponent<CharacterController2D>().isOnIce = true;
        }
        animator.SetBool("IsJumping", false);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ice")
        {
            gameObject.GetComponent<CharacterController2D>().isOnIce = false;
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
