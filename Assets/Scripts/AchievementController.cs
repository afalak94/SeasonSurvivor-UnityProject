using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour {

    public int highscore1, highscore2, highscore3;
    private bool adventureStarted = false, allLevelsPlayed = false, seasonScores = false, eatenAlive = false;
    public int zombieDeaths;
    public Button[] lockButtons;

    public Text hiddenText;
    void Start () {
        zombieDeaths = PlayerPrefs.GetInt("Devoured");
        highscore1 = PlayerPrefs.GetInt("HighScore1");
        highscore2 = PlayerPrefs.GetInt("HighScore2");
        highscore3 = PlayerPrefs.GetInt("HighScore3");
        //achievement 1
        if (highscore1 > 0)
        {
            adventureStarted = true;
        }
        //achievement 2
        if(highscore1 > 0 && highscore2 > 0 && highscore3 > 0)
        {
            allLevelsPlayed = true;
        }
        //achievement 3
        if((highscore1 + highscore2 + highscore3) >= 2600)
        {
            seasonScores = true;
        }
        //achievement 4
        if (zombieDeaths >= 3)
        {
            eatenAlive = true;
        }

    }
	
	// Update is called once per frame
	void Update () {
        
        if(adventureStarted == true){
            lockButtons[0].gameObject.SetActive(false);
        }

        if(allLevelsPlayed == true)
        {
            lockButtons[1].gameObject.SetActive(false);
        }

        if(seasonScores == true)
        {
            lockButtons[2].gameObject.SetActive(false);
        }

        if(eatenAlive == true)
        {
            lockButtons[3].gameObject.SetActive(false);
            hiddenText.text = "Devoured by zombie 3 or more times";
        }
    }
}
