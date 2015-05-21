using UnityEngine;
using System.Collections;

public class HittingEnemyScript : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		checkForPlayer ();
	
	}

	void checkForPlayer() {

		//kommt noch.

	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Box") {

			//moveSpeed *= -1;

			transform.RotateAround (transform.position, transform.up, 180f);


		}

		if (col.gameObject.tag == "Player") {
			
			Destroy(col.gameObject);
			
		}

	}
	
}

