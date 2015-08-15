using UnityEngine;
using System.Collections;

public class rotatingFireScript : MonoBehaviour {
	public Transform rotateAroundPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(rotateAroundPoint.position, Vector3.forward, 75 * Time.deltaTime);
	}
}
