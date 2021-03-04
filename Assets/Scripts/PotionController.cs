using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public enum PotionType
    {
        Speed,
        Jump,
    }

    public PotionType potionType;
    public int potionModAmount = 0;
    public AudioClip potionClip;
    public Vector3 potionStartpos;
    public GameObject potionHolder;
    public float minTimer;
    private float maxTimer = 8f;
    private RigidbodyConstraints2D originalConstraints;
    private void Start()
    {
        potionStartpos = this.transform.localPosition;
        originalConstraints = this.GetComponent<Rigidbody2D>().constraints;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if (potionType == PotionType.Jump)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasJumpPotion = true;
            }
            else if (potionType == PotionType.Speed)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasSpeedPotion = true;
            }

            collision.gameObject.GetComponent<PlayerMovement>().potionModAmount = potionModAmount;
            AudioSource.PlayClipAtPoint(potionClip, transform.position);
            //this.transform.localPosition = potionHolder.transform.localPosition;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            StartCoroutine("RespawnPotion");
            
        }
    }
    IEnumerator RespawnPotion()
    {
        while (true)
        {
            if (minTimer >= maxTimer)
            {
                //spawn an enemy
                this.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<CircleCollider2D>().enabled = true;
                this.GetComponent<BoxCollider2D>().enabled = true;
                this.GetComponent<Rigidbody2D>().constraints = originalConstraints;
                minTimer = 0;
                break;
            }

            minTimer += .01f;
            yield return new WaitForSeconds(.01f);
        }

    }



}


