using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	private bool pause=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
