using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
    }
}
