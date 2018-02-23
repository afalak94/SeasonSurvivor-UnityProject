using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {


    public static AudioClip laser;
    static AudioSource audioSrc;
	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
