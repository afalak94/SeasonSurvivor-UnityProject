using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	public static int score;
    public int highScore;

	public Image[] scoreImage;
	public Sprite[] scoreSprites;

    public Text highscoreText;
    public Text newHighscore;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("HighScore1") != 0)
        {
            highScore = PlayerPrefs.GetInt("HighScore1");
        }
        highscoreText.text = "Highscore: " + highScore;
    }
	
	// Update is called once per frame
	void Update () {

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore1", highScore);
            newHighscore.gameObject.SetActive(true);
        }

        int ones = score % 10;
        int tens = (score % 100) / 10;
        int hundreds = (score % 1000) / 100;
        int thousands = score / 1000;

        scoreImage[0].sprite = ScoreTexturePlacement(ones);
        scoreImage[1].sprite = ScoreTexturePlacement(tens);
        scoreImage[2].sprite = ScoreTexturePlacement(hundreds);
        scoreImage[3].sprite = ScoreTexturePlacement(thousands);

    }

	public Sprite ScoreTexturePlacement(int unit) {
		if (unit == 0) {
			return scoreSprites [0];
		}
		if (unit == 1) {
			return scoreSprites [1];
		}
		if (unit == 2) {
			return scoreSprites [2];
		}
		if (unit == 3) {
			return scoreSprites [3];
		}
		if (unit == 4) {
			return scoreSprites [4];
		}
		if (unit == 5) {
			return scoreSprites [5];
		}
		if (unit == 6) {
			return scoreSprites [6];
		}
		if (unit == 7) {
			return scoreSprites [7];
		}
		if (unit == 8) {
			return scoreSprites [8];
		}
		if (unit == 9) {
			return scoreSprites [9];
		}

		return null;
	}
}
