using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public Text timeText;
    public Text CoinText;

  
    public GameObject endLevelCanvas;
    public GameObject player;
    public GameObject UI;
    void Start()
    {
        timeText = timeText.GetComponent<Text>();
        CoinText = CoinText.GetComponent<Text>();
        endLevelCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
            endLevel();
    }

   public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void endLevel()
    {
        if (player.GetComponent<CharacterController2D>().levelComplete)
        {
            Time.timeScale = 0;
            timeText.text = "Your Time was " + UI.GetComponent<UIManager>().time + " seconds ";
            CoinText.text = "You Collected " + UI.GetComponent<UIManager>().coins + "/9 Coins";
            endLevelCanvas.SetActive(true);


        }
    }
}
