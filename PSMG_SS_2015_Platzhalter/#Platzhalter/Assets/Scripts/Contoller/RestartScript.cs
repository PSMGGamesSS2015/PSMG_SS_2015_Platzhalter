using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {
	public int scene;
	// Use this for initialization
	void Start () {
		scene = GameObject.Find ("LevelSelector").GetComponent<LevelScript> ().lastLevelPlayed;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Submit")){
			if(scene==1){
				Application.LoadLevel("Level 1");

			}
			else if(scene==2){
				Application.LoadLevel ("Level 1 Boss");
			}
		}
	}
}
