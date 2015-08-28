using UnityEngine;
using System.Collections;

public class LevelCheck : MonoBehaviour {

	/*
	 * Script for an indestructible object to check which level the player has already finished
	 */

	public bool levelOneDone = false;
	public bool levelTwoDone = false;
	public bool levelThreeDone = false;
	public bool levelFourDone = false;
	public bool levelFiveDone = false;

	void Start () {
		if (levelTwoDone == true) {
			GameObject.Find("UI_Controller").GetComponent<UIScript>().unlock_w3();
		}
	}

	void Update () {
		DontDestroyOnLoad (transform.gameObject);
	}

}
