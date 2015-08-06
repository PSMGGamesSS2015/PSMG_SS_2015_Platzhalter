using UnityEngine;
using System.Collections;

public class SchneeBossScript : MonoBehaviour {

	public Vector3 targetLeftPosition; 
	public Vector3 targetRightPosition; 
	public Vector3 targetMiddleLeftPosition;
	public Vector3 targetMiddleRightPosition;
	public Vector3 targetRightTopPosition;

	private float rotation=180;

	// Use this for initialization
	void Start () {
	
		StartCoroutine(waitAtBeginning());
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator waitAtBeginning(){
		
		yield return new WaitForSeconds (1f);
		
		StartCoroutine(moveLeftAndWait());
	}

	IEnumerator moveLeftAndWait(){
		
		var pointA = transform.position;
		var pointC = targetLeftPosition;
				
		yield return StartCoroutine(MoveObject(transform, pointA, pointC, 0.5f));

		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.RotateAround (point, Vector3.up, rotation);

		yield return new WaitForSeconds(1.2f);
		StartCoroutine(moveMiddleLeftAndWait());

	}

	IEnumerator moveMiddleLeftAndWait(){
		
		var pointA = transform.position;
		var pointC = targetMiddleLeftPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointC, 0.5f));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		yield return new WaitForSeconds(1.2f);
		StartCoroutine(moveTopRightAndWait());
		
	}

	IEnumerator moveTopRightAndWait(){
		
		var pointA = transform.position;
		var pointC = targetRightTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointC, 0.5f));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.RotateAround (point, Vector3.up, rotation);
		
		yield return new WaitForSeconds(1.2f);
		StartCoroutine(moveMiddleRightAndWait());
		
	}

	IEnumerator moveMiddleRightAndWait(){
		
		var pointA = transform.position;
		var pointC = targetMiddleRightPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointC, 0.5f));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		yield return new WaitForSeconds(1.2f);
		StartCoroutine(moveBackToStart());
		
	}

	IEnumerator moveBackToStart(){

		var pointA = transform.position;
		var pointC = targetRightPosition;

		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.RotateAround (point, Vector3.up, rotation);
		yield return StartCoroutine(MoveObject(transform, pointA, pointC, 0.5f));
		
		Vector3 point2 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.RotateAround (point2, Vector3.up, rotation);
		yield return new WaitForSeconds(1.2f);
		
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
