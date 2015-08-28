using UnityEngine;
using System.Collections;

public class BossEndScript : MonoBehaviour {


	/*
	 * Script for the star, that falls down when the player kills the boss. handles what happens if the player collects it, and lets it rotate and scale for a neat animation 
	 */
	private float angle =3f;
	private float minimalScale=1f;
	private float maximalScale=1.3f;
	public AudioSource endClip ;
	public AudioSource bg;

	void Start () {
	}

	void Update () {
		foreach (Transform childTransform in this.transform) {
			childTransform.gameObject.transform.Rotate (transform.up, angle);
		}
		Vector3 newScale = Vector3.one;
		float sin = (maximalScale-minimalScale)*(Mathf.Abs (Mathf.Sin (Time.timeSinceLevelLoad)));
		newScale *= minimalScale+ sin;
		transform.localScale = newScale;
	}

	void destroyItem(){
		foreach (Transform childTransform in this.transform) {
			Destroy(childTransform.gameObject);
		}
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			destroyItem ();
			Destroy (GameObject.Find("LevelSelector").gameObject);
			if(Application.loadedLevelName=="Level 1 Boss"){
				GameObject.Find ("_GM").GetComponent<LevelCheck>().levelOneDone =true;
			}else if(Application.loadedLevelName=="Level 2 Boss"){
				GameObject.Find ("_GM").GetComponent<LevelCheck>().levelTwoDone =true;
			}else if(Application.loadedLevelName=="Level 3 Boss"){
				GameObject.Find ("_GM").GetComponent<LevelCheck>().levelThreeDone =true;
			}else if(Application.loadedLevelName=="Level 4 Boss"){
				GameObject.Find ("_GM").GetComponent<LevelCheck>().levelFourDone =true;
			}else if(Application.loadedLevelName=="Level 5 Boss"){
				GameObject.Find ("_GM").GetComponent<LevelCheck>().levelFiveDone =true;
			}
			Application.LoadLevel("Level Select");

		}
	}
}
