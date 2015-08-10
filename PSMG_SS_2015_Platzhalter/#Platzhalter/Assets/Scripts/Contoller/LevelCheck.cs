using UnityEngine;
using System.Collections;

public class LevelCheck : MonoBehaviour {

	public bool levelOneDone = false;
	public bool levelTwoDone = false;
	public bool levelThreeDone = false;
	public bool levelFourDone = false;
	public bool levelFiveDone = false;

	void Start () {
	
	}

	void Update () {
		DontDestroyOnLoad (transform.gameObject);
	}

}
