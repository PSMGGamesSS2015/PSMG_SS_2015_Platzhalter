using UnityEngine;
using System.Collections;

public class fireBallScript : MonoBehaviour {
	public Transform pos1;
	public Vector3 pointB;
	void Start () {
		pointB = pos1.position;
	}

	void Update () {
		StartCoroutine (Moving ());
	}

	IEnumerator Moving(){
		Vector3 pointA = transform.position;
		while (true) {
			yield return StartCoroutine (MoveObject (transform, pointA,pointB, 2f));
			yield return StartCoroutine (MoveObject (transform, pointB,pointA, 2f));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}
