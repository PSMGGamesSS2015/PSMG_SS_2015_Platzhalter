using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	/**
	 * Script for the object at the end of the level, which teleports the player to the boss
	 */
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.tag == "Player") {
			if(Application.loadedLevelName=="Level 1"){
				float fadeTime = GameObject.Find ("_GM").GetComponent<Fading>().BeginFade(1);
				StartCoroutine( waitforfade(fadeTime));
				Destroy (GameObject.Find("LevelSelector").gameObject);
				Application.LoadLevel("Level 1 Boss");
			}
			if(Application.loadedLevelName=="Level 2"){
				float fadeTime = GameObject.Find ("_GM").GetComponent<Fading>().BeginFade(1);
				StartCoroutine( waitforfade(fadeTime));
				Destroy (GameObject.Find("LevelSelector").gameObject);
				Application.LoadLevel("Level 2 Boss");
			}
			if(Application.loadedLevelName=="Level 3"){
				float fadeTime = GameObject.Find ("_GM").GetComponent<Fading>().BeginFade(1);
				StartCoroutine( waitforfade(fadeTime));
				Destroy (GameObject.Find("LevelSelector").gameObject);
				Application.LoadLevel("Level 3 Boss");
			}
			if(Application.loadedLevelName=="Level 4"){
				float fadeTime = GameObject.Find ("_GM").GetComponent<Fading>().BeginFade(1);
				StartCoroutine( waitforfade(fadeTime));
				Destroy (GameObject.Find("LevelSelector").gameObject);
				Application.LoadLevel("Level 4 Boss");
			}
			if(Application.loadedLevelName=="Level 5"){
				float fadeTime = GameObject.Find ("_GM").GetComponent<Fading>().BeginFade(1);
				StartCoroutine( waitforfade(fadeTime));
				Destroy (GameObject.Find("LevelSelector").gameObject);
				Application.LoadLevel("Level 5 Boss");
			}
		}
	}
	IEnumerator waitforfade(float fadeTime){
		yield return new WaitForSeconds(fadeTime);
	}
}
