using UnityEngine;
using System.Collections;

public class LevelCheck : MonoBehaviour {

	public bool levelOneDone = false;
	public bool levelTwoDone = false;
	public bool levelThreeDone = false;
	public bool levelFourDone = false;
	public bool levelFiveDone = false;

	// Use this for initialization
	void Start () {
		if (levelTwoDone == true) {
			GameObject.Find("UI_Controller").GetComponent<UIScript>().unlock_w3();
		}
	}


	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (transform.gameObject);
	}

}
