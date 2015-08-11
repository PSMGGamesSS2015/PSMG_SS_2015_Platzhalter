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
	if (GameObject.Find ("PlayerLifes").GetComponent<LifeScript> ().lifes > 0) {

			if (scene == 1) {
				Destroy(GameObject.Find("LevelSelector"));
				Application.LoadLevel ("Level 1");
			} else if (scene == 2) {
				Destroy(GameObject.Find("LevelSelector"));
				Application.LoadLevel ("Level 1 Boss");
			} else if (scene == 3) {
				Destroy(GameObject.Find("LevelSelector"));
				Application.LoadLevel ("Level 2");
			}else if (scene == 4) {
				Destroy(GameObject.Find("LevelSelector"));
				Application.LoadLevel ("Level 2 Boss");
			}else if (scene == 5) {
				Destroy(GameObject.Find("LevelSelector"));
				Application.LoadLevel ("Level 3");
			}else if (scene == 6) {
				Destroy(GameObject.Find("LevelSelector"));
				Application.LoadLevel ("Level 3 Boss");
			}
		} else
			Application.LoadLevel ("Level Select");
	}
}
