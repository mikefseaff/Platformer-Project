using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    public Sprite cooledLava;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = cooledLava;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerAttack")
        {
            changeSprite();
            gameObject.tag = "transformedPlatform";
            gameObject.layer = 8;
        }
    }
}
