﻿using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {
	public int lastLevelPlayed =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake(){

		DontDestroyOnLoad (transform.gameObject);
	}
}
