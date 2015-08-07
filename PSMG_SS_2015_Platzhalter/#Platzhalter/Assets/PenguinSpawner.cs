using UnityEngine;
using System.Collections;

public class PenguinSpawner : MonoBehaviour {

	public GameObject penguin;
	private GameObject peng;
	// Use this for initialization
	void Start () {
		InvokeRepeating("spawn", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y-1.5f, transform.position.z);
		peng = Instantiate (penguin,pos,transform.rotation) as GameObject;

	}
}
