using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text textbox;
    public float time;
    void Start()
    {
        textbox = textbox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        textbox.text = "Time: " + time;
    }
}
