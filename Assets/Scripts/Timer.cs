using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeLeft = 100;
    public Text countdownText;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void Update () {
        countdownText.text = ("Time: " + timeLeft);

        if(timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times up!";
            GameObject.Find("Player").GetComponent<PlayerHealth>().EndGame();
        }
	}

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
