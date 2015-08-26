using UnityEngine;
using System.Collections;

public class skittler : MonoBehaviour {
	
	public float moveSpeed = -2f;




	
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, moveSpeed, 0) * Time.deltaTime);
		

	}

	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Box") {
			moveSpeed*=-1;
			if(moveSpeed<0){
				foreach (Transform child in transform)
				{
					child.gameObject.transform.localEulerAngles = new Vector3(90,255,180);
				}
			}
			else if(moveSpeed>0){
				foreach(Transform child in transform){
					child.gameObject.transform.localEulerAngles = new Vector3(270,255,0);
				}
				
			}
		}
		

	}
}
