using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5f;
	public float jumpDist = 5f;

	private Rigidbody2D playerRB;
	private SpriteRenderer rend;
	private bool isFlipped;
	private Animator anim;
	private bool isGrounded;

    public bool devoured = false;

    // Use this for initialization


    public void Awake () {
        Time.timeScale = 1;
        playerRB = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();

        //GameObject score = GameObject.Find("Score");
        //ScoreSystem score_system = score.GetComponent<ScoreSystem>();
        //score_system.
        ScoreSystem.score = 0;
        ScoreSystem2.score = 0;
        ScoreSystem3.score = 0;

        float move = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(move * moveSpeed, playerRB.velocity.y);


    }

	void Update(){
		if (!GameObject.Find("Player").GetComponent<PlayerHealth>().isDead) {
			if (Input.GetButtonDown ("Jump")) {
				playerRB.AddForce (Vector2.up * jumpDist);
				anim.SetBool ("hasJumped", true);
				isGrounded = false;
			}
		}

        //from fixed
        if (!GameObject.Find("Player").GetComponent<PlayerHealth>().isDead)
        {
            float move = Input.GetAxis("Horizontal");

            playerRB.velocity = new Vector2(move * moveSpeed, playerRB.velocity.y);

            if (move < 0)
            {
                isFlipped = true;
            }
            else if (move > 0)
            {
                isFlipped = false;
            }

            if (move != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else {
                anim.SetBool("isWalking", false);
            }

            if (isGrounded == false)
            {
                anim.SetBool("hasJumped", true);
            }
            else {
                anim.SetBool("hasJumped", false);
            }
            Flip();
        }
    }
	
	// Update is called once per frame


	void Flip(){
		if (isFlipped == false) {
			rend.flipX = false;
		}else
			rend.flipX = true;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
		}
		if (col.gameObject.tag == "spikes") {
			GetComponent<PlayerHealth> ().Damage ();
			Hit();
            devoured = false;
        }
        if (col.gameObject.tag == "projectile")
        {
            GetComponent<PlayerHealth>().Damage();
            Hit();
            devoured = false;
        }
        if (col.gameObject.tag == "slime" || col.gameObject.tag == "saw")
        {
            devoured = false;
        }
        if (col.gameObject.tag == "GarbageCollector")
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().EndGame();
            devoured = false;
        }
        if (col.gameObject.tag == "zombie")
        {
            devoured = true;
        }
    }

	void Hit() {
		if (Random.value <= 0.5f) {
			playerRB.AddForce (Vector2.up * (jumpDist * 1.1f));
			playerRB.AddForce (Vector2.right * (jumpDist * 1.1f));
		} else {
			playerRB.AddForce (Vector2.up * (jumpDist * 1.1f));
			playerRB.AddForce (Vector2.left * (jumpDist * 1.1f));
		}
	}


}
