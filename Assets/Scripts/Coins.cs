using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

    public int scoreGiven = 10;
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if(Application.loadedLevel == 2)
            {
                ScoreSystem.score += scoreGiven;
                Destroy(gameObject);
            }
            if (Application.loadedLevel == 3)
            {
                ScoreSystem2.score += scoreGiven;
                Destroy(gameObject);
            }
            if (Application.loadedLevel == 4)
            {
                ScoreSystem3.score += scoreGiven;
                Destroy(gameObject);
            }
        }
    }
}
