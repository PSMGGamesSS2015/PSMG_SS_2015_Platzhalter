using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {
	public int lastLevelPlayed;
	/*
	 * Script for an indestructible object(except at the end of each level), that is checked when you respawn
	 */
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}
