using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStonePickUp : MonoBehaviour
{
    public AudioClip pickupClip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coinCollider")
        {

            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>().totalCoins++;
            Debug.Log("hit");
            Destroy(this.gameObject);
         
           

        }
    }
}
