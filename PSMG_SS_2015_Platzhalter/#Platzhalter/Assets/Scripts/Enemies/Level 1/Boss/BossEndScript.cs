using UnityEngine;
using System.Collections;

public class BossEndScript : MonoBehaviour {
	private float angle =3f;
	private float minimalScale=1f;
	private float maximalScale=1.3f;
	public AudioSource endClip ;
	public AudioSource bg;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		foreach (Transform childTransform in this.transform) {
			childTransform.gameObject.transform.Rotate (transform.up, angle);
		}
		Vector3 newScale = Vector3.one;
		float sin = (maximalScale-minimalScale)*(Mathf.Abs (Mathf.Sin (Time.timeSinceLevelLoad)));
		newScale *= minimalScale+ sin;
		transform.localScale = newScale;
	}
	IEnumerator EndLevel(){
		destroyItem ();
		Destroy (GameObject.Find("LevelSelector").gameObject);
		GameObject.Find ("LevelCheck").GetComponent<LevelCheck>().levelOneDone =true;
		yield return new WaitForSeconds (1.2f);
	}
	IEnumerator StartNewLevel(){

		Application.LoadLevel("Level Select");
		yield return new WaitForEndOfFrame ();
	}
	void destroyItem(){
		foreach (Transform childTransform in this.transform) {
			Destroy(childTransform.gameObject);
		}
		Destroy (this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			StartCoroutine(EndLevel());
			StartCoroutine(StartNewLevel());
		}
	}
}
