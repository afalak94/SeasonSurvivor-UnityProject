using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpSound : MonoBehaviour {

    public AudioSource sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound.Play();
        }

    }
}
