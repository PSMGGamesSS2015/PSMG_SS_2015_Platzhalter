using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {

	public int speed;
	public int selection;
	public Transform platform;
	public Transform currentPoint;
	public Transform[] points;
	// Use this for initialization
	void Start () {
		currentPoint = points [selection];
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, currentPoint.position, Time.deltaTime * speed);

		if (transform.position == currentPoint.position) {
			selection++;
			if(selection == points.Length){
				selection=0;
			}
			currentPoint= points[selection];
		}
	}


}
