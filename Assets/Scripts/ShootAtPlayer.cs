using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootAtPlayer : MonoBehaviour {

    public float playerRange;
    public GameObject projectile;
    private SpriteRenderer rend;

    public PlayerController player;

    public Transform launchPoint;

    private bool isFlipped = true;

    public float waitBshots;
    private float shotCounter;

    public AudioSource audioSrc;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        rend = GetComponent<SpriteRenderer>();
        shotCounter = waitBshots;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        shotCounter -= Time.deltaTime;
		if(player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
            isFlipped = false;
            Flip();
            GameObject clone = Instantiate(projectile, launchPoint.position, launchPoint.rotation) as GameObject;
            audioSrc.Play();
            shotCounter = waitBshots;
            Destroy(clone, 4);
        }
        if (player.transform.position.x > transform.position.x + playerRange && shotCounter < 0)
        {
            isFlipped = true;
            Flip();
            GameObject clone = Instantiate(projectile, launchPoint.position, launchPoint.rotation) as GameObject;
            audioSrc.Play();
            shotCounter = waitBshots;
            Destroy(clone, 4);
        }
    }

    void Flip()
    {
        if (isFlipped == false)
        {
            rend.flipX = false;
            
        }
        else
            rend.flipX = true;
            
    }
}
