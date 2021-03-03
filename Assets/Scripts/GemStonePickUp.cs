using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStonePickUp : MonoBehaviour
{
    public AudioClip pickupClip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {

            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            Destroy(this.gameObject);

        }
    }
}
