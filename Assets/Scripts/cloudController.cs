using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudController : MonoBehaviour
{
    public GameObject ice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnIce()
    {
        GameObject icePlatform = GameObject.Instantiate(ice, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, 0));
        icePlatform.transform.localScale = new Vector3(transform.localScale.x*4, transform.localScale.y, transform.localScale.z);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerAttack")
        {
            spawnIce();
            gameObject.tag = "transformedPlatform";
            gameObject.layer = 8;
        }
    }
}
