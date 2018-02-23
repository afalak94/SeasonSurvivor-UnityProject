using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    public Text highScore1Text;
    public Text highScore2Text;
    public Text highScore3Text;

    public int highscore1, highscore2, highscore3;

    // Use this for initialization
    void Start () {
        highscore1 = PlayerPrefs.GetInt("HighScore1");
        highscore2 = PlayerPrefs.GetInt("HighScore2");
        highscore3 = PlayerPrefs.GetInt("HighScore3");
    }
	
	// Update is called once per frame
	void Update () {

        highScore1Text.text = "High Score: " + highscore1;
        highScore2Text.text = "High Score: " + highscore2;
        highScore3Text.text = "High Score: " + highscore3;

    }
}
