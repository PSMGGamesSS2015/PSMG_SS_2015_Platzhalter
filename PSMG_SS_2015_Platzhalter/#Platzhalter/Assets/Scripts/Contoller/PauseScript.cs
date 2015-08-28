using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	private bool pause=false;

	/*
	 * script for pausing the game
	 */

	void Update () {
		if (Input.GetButtonDown ("Submit")) {
			pause = !pause;
			if(pause){
				Time.timeScale = 0;
				GameObject.Find("barrel").GetComponent<Shooting>().enabled=false;
			}
			else if(!pause){
				Time.timeScale = 1;
				GameObject.Find("barrel").GetComponent<Shooting>().enabled=true;
			}
			GameObject.Find ("UI_Controller").GetComponent<UIScript> ().togglePause();
			
		}
	}
}
