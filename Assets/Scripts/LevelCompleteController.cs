using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public Text timeText;
    public Text CoinText;

    public GameObject timeController;
    public GameObject coinController;
    public GameObject endLevelCanvas;
    public GameObject player;
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
            timeText.text = "Your Time was " + timeController.GetComponent<TimeController>().time + " seconds ";
            CoinText.text = "You Collected " + coinController.GetComponent<coinCounterController>().coins + "/9 Coins";
            endLevelCanvas.SetActive(true);


        }
    }
}
