﻿using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Debug.Log ("falltodeath");
		}
		Debug.Log ("dunno");
	}
}
