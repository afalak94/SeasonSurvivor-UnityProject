using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed;
    public PlayerController player;
    public int damage;

    private Rigidbody2D myrigidbody2D;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        myrigidbody2D = GetComponent<Rigidbody2D>();

        if(player.transform.position.x < transform.position.x)
        {
            speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        myrigidbody2D.velocity = new Vector2(speed, myrigidbody2D.velocity.y);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SendMessage("Damage");
            //GetComponent<PlayerHealth>().Damage();
        }
        if (other.tag == "ground")
        {
            Destroy(gameObject);
        }

    }
}
