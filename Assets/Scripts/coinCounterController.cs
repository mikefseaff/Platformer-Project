using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCounterController : MonoBehaviour
{
    public Text textbox;
    public GameObject player;
    public int coins;
    void Start()
    {
        textbox = textbox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coins = player.GetComponent<CharacterController2D>().totalCoins;
        textbox.text = "Coins:  " + coins + "/9";
    }
}
