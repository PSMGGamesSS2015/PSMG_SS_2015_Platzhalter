using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.tag == "Player") {
			if(Application.loadedLevelName=="Level 1"){
				float fadeTime = GameObject.Find ("EventSystem").GetComponent<Fading>().BeginFade(1);
				StartCoroutine( waitforfade(fadeTime));
				Destroy (GameObject.Find("LevelSelector").gameObject);
				Application.LoadLevel("Level 1 Boss");
			}
			if(Application.loadedLevelName=="Level 2"){
				float fadeTime = GameObject.Find ("EventSystem").GetComponent<Fading>().BeginFade(1);
				StartCoroutine( waitforfade(fadeTime));
				Destroy (GameObject.Find("LevelSelector").gameObject);
				Application.LoadLevel("Level 2 Boss");
			}
		}
	}
	IEnumerator waitforfade(float fadeTime){
		yield return new WaitForSeconds(fadeTime);
	}
}
