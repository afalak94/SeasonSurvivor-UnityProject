using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int health;
	private int maxHealth = 5;

	public Texture2D fullHeart, halfHeart, emptyHeart;
	private Texture2D heart1, heart2, heart3, heart4, heart5;

	public Vector2 HealthPos;

	public bool isDead = false;

    public Text DeadText, againText, menuText;

    public int killedByZombie;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        health = maxHealth;

		heart1 = fullHeart;
		heart2 = fullHeart;
		heart3 = fullHeart;
		heart4 = fullHeart;
		heart5 = fullHeart;

        killedByZombie = PlayerPrefs.GetInt("Devoured");
    }
	
	// Update is called once per frame
	void Update () {
		HealthMonitor ();
	}

	void HealthMonitor(){
		if (health == maxHealth) {
			heart1 = fullHeart;
			heart2 = fullHeart;
			heart3 = fullHeart;
			heart4 = fullHeart;
			heart5 = fullHeart;
		}
		if (health == maxHealth - 1) {
			heart1 = fullHeart;
			heart2 = fullHeart;
			heart3 = fullHeart;
			heart4 = fullHeart;
			heart5 = emptyHeart;
		}
		if (health == maxHealth - 2) {
			heart1 = fullHeart;
			heart2 = fullHeart;
			heart3 = fullHeart;
			heart4 = emptyHeart;
			heart5 = emptyHeart;
		}
		if (health == maxHealth - 3) {
			heart1 = fullHeart;
			heart2 = fullHeart;
			heart3 = emptyHeart;
			heart4 = emptyHeart;
			heart5 = emptyHeart;
		}
		if (health == maxHealth - 4) {
			heart1 = fullHeart;
			heart2 = emptyHeart;
			heart3 = emptyHeart;
			heart4 = emptyHeart;
			heart5 = emptyHeart;
		}
		if (health <= 0) {
			heart1 = emptyHeart;
			heart2 = emptyHeart;
			heart3 = emptyHeart;
			heart4 = emptyHeart;
			heart5 = emptyHeart;
			EndGame ();
		}
	}

	public void EndGame(){
		isDead = true;

        if(GetComponent<PlayerController>().devoured == true)
        {
            PlayerPrefs.SetInt("Devoured", killedByZombie + 1);
        }

        DeadText.gameObject.SetActive(true);
        againText.gameObject.SetActive(true);
        menuText.gameObject.SetActive(true);

        Time.timeScale = 1;
        if(gameObject != null)
        {
            Destroy(gameObject);
        }

    }


    public void Damage(){
		health -= 1;
	}

	void OnGUI(){
		GUI.BeginGroup (new Rect (HealthPos.x, HealthPos.y, 500, 100));
		GUI.DrawTexture (new Rect (0, 0, 100, 100), heart1, ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (100, 0, 100, 100), heart2, ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (200, 0, 100, 100), heart3, ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (300, 0, 100, 100), heart4, ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (400, 0, 100, 100), heart5, ScaleMode.ScaleToFit);

		GUI.EndGroup ();
	}
}
