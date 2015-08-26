using UnityEngine;
using System.Collections;

public class rotatingFireScript : MonoBehaviour {
	public Transform rotateAroundPoint;
	public int dir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAround (rotateAroundPoint.position, Vector3.forward * dir, 75 * Time.deltaTime);

	}
}
