﻿using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Ground") {
			Destroy (this.gameObject);
		}

	}
}
