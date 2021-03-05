using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timeText;
    public Text coinText;
    public float time;
    public int coins;
    public GameObject UICanvas;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + time;

        coins = player.GetComponent<CharacterController2D>().totalCoins;
        coinText.text = "Coins:  " + coins + "/9";
    }

}
