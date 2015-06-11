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
	public GameObject projectile;
	private GameObject bullet;
	private float distance= 0.7f;
	private float speed = -25f;
	private float vertical = 0f;

	private float health = 200;

	private float rotation=240;
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

	private void moveMiddle(){
		
		StartCoroutine(moveMiddleAndWait());
				
	}

	private void groundStomp(){
		
		StartCoroutine (moveMiddleTopAndWait ());
		
	}

	private void moveRight(){
		
		StartCoroutine(moveRightAndWait());
				
	}

	private void fireStraight(){
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, vertical));
		Destroy(bullet.gameObject, distance);
	}

	private void fireArc(){
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-4,-8), Random.Range(15f,20f)));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-6,-10), Random.Range(20f,25f)));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-10,-12), Random.Range(25f,30f)));
		Destroy(bullet.gameObject, 3f);
	}

	IEnumerator shootStraightRAndWait() {

		yield return new WaitForSeconds(1);
		fireStraight ();
		yield return new WaitForSeconds(2);
		fireStraight ();
		yield return new WaitForSeconds(2);
		fireStraight ();
		yield return new WaitForSeconds(2);

		rightArc ();

	}

	IEnumerator shootArcRAndWait() {
		
		yield return new WaitForSeconds(1);
		fireArc();
		yield return new WaitForSeconds(2);
		fireArc();
		yield return new WaitForSeconds(2);
		fireArc();
		yield return new WaitForSeconds(2);

		moveLeft ();

	}

	IEnumerator shootStraightLAndWait() {
		
		yield return new WaitForSeconds(1);
		fireStraight ();
		yield return new WaitForSeconds(2);
		fireStraight ();
		yield return new WaitForSeconds(2);
		fireStraight ();
		yield return new WaitForSeconds(2);
		
		leftArc();
		
	}
	
	IEnumerator shootArcLAndWait() {
		
		yield return new WaitForSeconds(1);
		fireArc();
		yield return new WaitForSeconds(2);
		fireArc();
		yield return new WaitForSeconds(2);
		fireArc();
		yield return new WaitForSeconds(2);
		
		moveMiddle();
		
	}

	IEnumerator waitAtBeginning(){

		yield return new WaitForSeconds(2);

		rightStraight ();

	}

	IEnumerator moveLeftAndWait(){
		
		var pointA = transform.position;
		var pointB = targetLeftPosition;

		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));

		yield return new WaitForSeconds(2);
		leftStraight ();
		
	}

	IEnumerator moveRightAndWait(){
		
		var pointA = transform.position;
		var pointB = targetRightPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
		
		yield return new WaitForSeconds(2);
		rightStraight ();
		
	}

	IEnumerator moveMiddleAndWait(){
		
		var pointA = transform.position;
		var pointB = targetMiddlePosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
		
		yield return new WaitForSeconds(1);
		groundStomp ();
		
	}

	IEnumerator moveMiddleTopAndWait(){
		
		var pointA = transform.position;
		var pointB = targetMiddleTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
		
		yield return new WaitForSeconds(1);
		pointB = targetMiddlePosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));

		yield return new WaitForSeconds(1);
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
