using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	public int levelCheck;
	private float respawnTime=5.0f;
	
	void Start () {
		levelCheck = GameObject.Find ("LevelSelector").GetComponent<LevelScript> ().lastLevelPlayed;
	}

	void Update () {
		StartCoroutine (liveAgain ());
		if(Input.GetButtonDown ("Submit")||Input.GetButtonDown("Fire1")||Input.GetButtonDown("Jump")){
				restart();
		}
	}
	/*
	 * method to automatically restart the player after 5 seconds
	 */
	IEnumerator liveAgain(){
		yield return new WaitForSeconds(respawnTime);
		restart ();
	}

	/*
	 *	method to check which level the player has played before he died, and then respawns the player in that level.
	 */
	void restart(){
		if (GameObject.Find ("PlayerLifes").GetComponent<LifeScript> ().lifes > 0) {
				if (levelCheck == 1) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 1");
				} else if (levelCheck == 2) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 1 Boss");
				} else if (levelCheck == 3) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 2");
				}else if (levelCheck == 4) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 2 Boss");
				}else if (levelCheck == 5) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 3");
				}else if (levelCheck == 6) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 3 Boss");
				}
				else if (levelCheck ==7) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 4");
				}
				else if (levelCheck == 8) {
					Destroy(GameObject.Find("LevelSelector"));
					Application.LoadLevel ("Level 4 Boss");
				}
			} else
				Application.LoadLevel ("Level Select");
		}
}
