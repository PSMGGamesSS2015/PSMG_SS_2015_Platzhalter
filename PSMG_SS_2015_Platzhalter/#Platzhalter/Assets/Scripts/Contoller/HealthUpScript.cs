using UnityEngine;
using System.Collections;

public class HealthUpScript : MonoBehaviour {
	private float angle =3f;
	private float minimalScale=0.9f;
	private float maximalScale=1.3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
