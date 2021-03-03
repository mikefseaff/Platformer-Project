using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPos;
    Rigidbody2D attackRB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -360 *Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lava" || collision.gameObject.layer == 8 || collision.gameObject.tag == "transformedPlatform")
        {
            Destroy(this.gameObject);
        }
    }

}
