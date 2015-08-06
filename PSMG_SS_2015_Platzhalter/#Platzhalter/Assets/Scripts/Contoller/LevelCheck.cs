using UnityEngine;
using System.Collections;

public class LevelCheck : MonoBehaviour {

	public bool levelOneDone = false;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (transform.gameObject);
	}

}
