using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {

	public int lifes;

	// Use this for initialization
	void Start () {
		lifes = 3;
	}
	
	// Update is called once per frame
	void Update () {

		DontDestroyOnLoad (transform.gameObject);
	}
}
