﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "PlayerHB") {
			col.gameObject.SendMessageUpwards ("Damage");
			col.gameObject.SendMessageUpwards ("Hit");
		}
	}
}
