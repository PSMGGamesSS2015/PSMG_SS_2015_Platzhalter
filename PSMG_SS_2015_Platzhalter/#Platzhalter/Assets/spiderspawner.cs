using UnityEngine;
using System.Collections;

public class spiderspawner : MonoBehaviour {

	public GameObject spidermodel;
	private GameObject spider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.tag == "Ground") {
			Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			spider = Instantiate (spidermodel,pos , transform.rotation) as GameObject;
			//spider.transform.localEulerAngles.Set(0,0,270);
		}
	}
}
