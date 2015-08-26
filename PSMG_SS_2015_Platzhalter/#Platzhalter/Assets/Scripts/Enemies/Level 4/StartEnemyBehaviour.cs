using UnityEngine;
using System.Collections;

public class StartEnemyBehaviour : MonoBehaviour {

	private rotatingFireScript fire;
	// Use this for initialization
	void Start () {
		fire = FindObjectOfType<rotatingFireScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			//fire.rotationOn = true;
			Debug.Log ("Ficken");
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			//fire.rotationOn = false;
		}
	}
}
