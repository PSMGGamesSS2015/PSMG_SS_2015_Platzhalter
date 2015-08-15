using UnityEngine;
using System.Collections;

public class PenguinSpawner : MonoBehaviour {

	public GameObject penguin;
	private GameObject peng;
	// Use this for initialization
	void Start () {
		InvokeRepeating("spawn", 3f, 3f);
	}
	
	// Update is called once per frame
	void Update () {


	}
	void spawn(){
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y+1.7f, transform.position.z);
		peng = Instantiate (penguin,pos,transform.rotation) as GameObject;
		peng.GetComponent<PenguinScript> ().goal = GameObject.Find ("goalpenguin").transform;
	}
}
