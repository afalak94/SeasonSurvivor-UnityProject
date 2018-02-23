using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryProjectile : MonoBehaviour {

    public float destoryTime;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, destoryTime);
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject);
	}
}
