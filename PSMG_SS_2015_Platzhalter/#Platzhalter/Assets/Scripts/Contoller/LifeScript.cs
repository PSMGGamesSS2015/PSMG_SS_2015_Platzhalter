using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {

	public int lifes;

	/*
	 * script for handling how many lifes the player has, so he has only 3 tries for each level.
	 */

	void Start () {
		lifes = 3;
	}

	void Update () {

		DontDestroyOnLoad (transform.gameObject);
	}
}
