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
		StartCoroutine (liveAgain ());
		if(Input.GetButtonDown ("Submit")||Input.GetButtonDown("Fire1")||Input.GetButtonDown("Jump")){
			restart();

		}
	}
	IEnumerator liveAgain(){
		yield return new WaitForSeconds(5.0f);
		restart ();

	}
	void restart(){
		if(scene==1){
			Application.LoadLevel("Level 1");
			
		}
		else if(scene==2){
			Application.LoadLevel ("Level 1 Boss");
		}
	}
}
