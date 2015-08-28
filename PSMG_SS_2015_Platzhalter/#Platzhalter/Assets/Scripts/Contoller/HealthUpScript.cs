using UnityEngine;
using System.Collections;

public class HealthUpScript : MonoBehaviour {
	private float angle =3f;
	private float minimalScale=0.9f;
	private float maximalScale=1.3f;


	/*
	 * Script for the life-upgrades the enemies can drop. handled here is the rotation/scale of the object, and what happenes if the player collides with it.
	 * the actual "healing" is handled by the SimplePlatformController.cs
	 */
	void Update () {
		transform.Rotate (transform.up, angle);
		Vector3 newScale = Vector3.one;
		float sin = (maximalScale-minimalScale)*(Mathf.Abs (Mathf.Sin (Time.timeSinceLevelLoad)));
		newScale *= minimalScale+ sin;
		transform.localScale = newScale;
	}

	void destroyItem(){
		foreach (Transform childTransform in this.transform) {
			Destroy(childTransform.gameObject);
		}
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			destroyItem();
		}
	}
}
