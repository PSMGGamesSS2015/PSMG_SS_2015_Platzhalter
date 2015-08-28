using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {
	/*
	 * Script for moving platforms. for them to work you just need to give it a size for the point-array in the inspector, so it knows how many "goals" it has, and the points (vector3) themself.
	 */




	public int speed;
	public int selection;
	public Transform platform;
	public Transform currentPoint;
	public Transform[] points;


	void Start () {
		currentPoint = points [selection];
	}

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
