using UnityEngine;
using System.Collections;

public class GorillaBossScript : MonoBehaviour {

	public Vector3 targetLeftPosition; 
	public Vector3 targetRightPosition; 
	public Vector3 targetMiddlePosition;
	public Vector3 targetMiddleTopPosition;


	private Vector3 targetAngles;
	public float smooth = 1f;

	public float moveSpeed = 5f;
	
	//Bullet
	public GameObject projectileStraight,projectileCurve;
	private GameObject bullet;
	private float distance= 1f;
	private float speed = -25f;
	private float vertical = 0f;

	private float health = 500;

	private float rotation=180;
	private float zposition=-13;

	void Start()
	
	{	
		wait();

	}

	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
			Application.LoadLevel("Level Select");
		}

	}

	private void wait(){

		StartCoroutine(waitAtBeginning());

	}

	private void rightStraight(){
		
		StartCoroutine(shootStraightRAndWait());

	}

	private void rightArc(){
		
		StartCoroutine(shootArcRAndWait());
		
	}

	private void moveLeft(){
		
		StartCoroutine(moveLeftAndWait());
		
	}

	private void leftStraight(){
		
		StartCoroutine(shootStraightLAndWait());

	}

	private void leftArc(){
		
		StartCoroutine(shootArcLAndWait());
				
	}

	/*private void moveMiddle(){
		
		StartCoroutine(moveMiddleAndWait());
				
	}*/

	private void groundStomp(){
		
		StartCoroutine (moveMiddleTopAndWait ());
		
	}

	private void moveRight(){
		
		StartCoroutine(moveRightAndWait());
				
	}

	private void fireStraight(){
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y-1.5f, transform.position.z);
		bullet = Instantiate (projectileStraight,pos , transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, vertical));
		Destroy(bullet.gameObject, distance);
	}

	private void fireArcLeft(){
		Vector3 pos = new Vector3 (transform.position.x + 2, transform.position.y, transform.position.z);
		bullet = Instantiate (projectileCurve, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-4,-8), 12));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectileCurve, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-6,-10), 15));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectileCurve, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-10,-12), 18));
		Destroy(bullet.gameObject, 3f);
	}
	private void fireArcRight(){
		Vector3 pos = new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z);
		bullet = Instantiate (projectileCurve, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-4,-8), 12));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectileCurve, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-6,-10), 15));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectileCurve, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-10,-12), 18));
		Destroy(bullet.gameObject, 3f);
	}

	IEnumerator shootStraightRAndWait() {

		yield return new WaitForSeconds(0.5f);
		fireStraight ();
		yield return new WaitForSeconds(1.5f);
		fireStraight ();
		yield return new WaitForSeconds(1.5f);
		fireStraight ();
		yield return new WaitForSeconds(1.5f);

		rightArc ();

	}

	IEnumerator shootArcRAndWait() {
		
		yield return new WaitForSeconds(0.8f);
		fireArcLeft();
		yield return new WaitForSeconds(1.3f);
		fireArcLeft();
		yield return new WaitForSeconds(1.3f);
		fireArcLeft();
		yield return new WaitForSeconds(1.3f);

		moveLeft ();

	}

	IEnumerator shootStraightLAndWait() {
		
		yield return new WaitForSeconds(0.5f);
		fireStraight ();
		yield return new WaitForSeconds(1.5f);
		fireStraight ();
		yield return new WaitForSeconds(1.5f);
		fireStraight ();
		yield return new WaitForSeconds(1.5f);
		
		leftArc();
		
	}
	
	IEnumerator shootArcLAndWait() {
		
		yield return new WaitForSeconds(0.8f);
		fireArcRight();
		yield return new WaitForSeconds(1.3f);
		fireArcRight();
		yield return new WaitForSeconds(1.3f);
		fireArcRight();
		yield return new WaitForSeconds(1.3f);
		
		groundStomp();
		
	}

	IEnumerator waitAtBeginning(){

		yield return new WaitForSeconds(1f);

		rightStraight ();

	}

	IEnumerator moveLeftAndWait(){
		
		var pointA = transform.position;
		var pointC = targetLeftPosition;
		var pointB = targetMiddleTopPosition;

		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));
		yield return StartCoroutine (MoveObject (transform, pointB, pointC, 0.5f));

		transform.RotateAround (point, Vector3.up, rotation);
		transform.position = new Vector3 (112, 3, -9);

		yield return new WaitForSeconds(1.2f);
		leftStraight ();
		
	}

	IEnumerator moveRightAndWait(){
		
		var pointA = transform.position;
		var pointB/*C*/ = targetRightPosition;
		//var pointB = targetMiddleTopPosition;

		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));
		//yield return StartCoroutine (MoveObject (transform, pointB, pointC, 0.5f));

		transform.RotateAround (point, Vector3.up, rotation);
		transform.position = new Vector3 (128, 3, -8);

		yield return new WaitForSeconds(1.2f);
		rightStraight ();
		
	}

	/*IEnumerator moveMiddleAndWait(){
		
		var pointA = transform.position;
		var pointB = targetMiddlePosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));
		
		yield return new WaitForSeconds(1.2f);
		groundStomp ();
		
	}*/

	IEnumerator moveMiddleTopAndWait(){
		
		var pointA = transform.position;
		var pointB = targetMiddleTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));
		
		yield return new WaitForSeconds(0.5f);
		pointA = transform.position;
		pointB = targetMiddlePosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));

		yield return new WaitForSeconds(1.2f);
		moveRight ();
		
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
	private void onHit()
	{
		health -= 20;
	}
	
	void OnTriggerEnter2D(Collider2D collider){

		
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
		
	}

}
