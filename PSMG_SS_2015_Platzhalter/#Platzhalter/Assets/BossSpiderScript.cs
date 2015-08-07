using UnityEngine;
using System.Collections;

public class BossSpiderScript : MonoBehaviour {

	[HideInInspector]
	public Vector3 rightBottomPosition;
	[HideInInspector]
	public Vector3 rightTopPosition; 
	[HideInInspector]
	public Vector3 middleBottomPosition;
	[HideInInspector]
	public Vector3 middleTopPosition;
	[HideInInspector]
	public Vector3 leftBottomPosition;
	[HideInInspector]
	public Vector3 leftTopPosition;

	private float health = 400;
	private GameObject item;
	private float rotation=180;
	private float moveSpeed = 0.5f;
	private GameObject star;
	private GameObject player;
	public GameObject projectileStraight;
	public GameObject spider;
	private GameObject spiderspawn;
	private GameObject spiderspawn2;
	private GameObject bullet;
	private float speed = -25f;
	private float distance= 3.0f;


	// Use this for initialization
	void Start () {
		middleBottomPosition = new Vector3 (-7, 7, 0);
		middleTopPosition = new Vector3 (-7, 20, 0);
		rightBottomPosition = new Vector3 (3, 7, 0);
		rightTopPosition = new Vector3 (3, 20, 0);
		leftBottomPosition = new Vector3 (-17, 7, 0);
		leftTopPosition = new Vector3 (-17, 20, 0);
		star = GameObject.Find ("EndObject");
		StartCoroutine (waitAtBeginning());
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			item = Instantiate(star, new Vector3(-5,7,0),  Quaternion.identity) as GameObject;
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
			
		}
	}

	IEnumerator waitAtBeginning(){
		
		yield return new WaitForSeconds(1f);
		StartCoroutine (moveRightMiddleAndWait());

	}

	IEnumerator moveRightMiddleAndWait(){
		
		var pointA = transform.position;
		var pointB = rightBottomPosition;

		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed));

		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		StartCoroutine (pattern());
		yield return new WaitForSeconds(3.5f);
		StartCoroutine (moveRightTopAndWait());

	}

	IEnumerator moveRightTopAndWait(){
		
		var pointA = transform.position;
		var pointB = rightTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed/2));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		yield return new WaitForSeconds(1.2f);
		StartCoroutine (moveMiddleTopAndWait());

	}

	IEnumerator moveMiddleTopAndWait(){
		
		var pointA = transform.position;
		var pointB = middleTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed/2));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		yield return new WaitForSeconds(1.2f);
		StartCoroutine (moveMiddleBottomAndWait());
				
	}

	IEnumerator moveMiddleBottomAndWait(){
		
		var pointA = transform.position;
		var pointB = middleBottomPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		StartCoroutine (pattern());
		yield return new WaitForSeconds(3.5f);
		StartCoroutine (moveMiddleTopAndWait2());
		
	}

	IEnumerator moveMiddleTopAndWait2(){
		
		var pointA = transform.position;
		var pointB = middleTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed/2));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		
		yield return new WaitForSeconds(1.2f);
		StartCoroutine (moveLeftTopAndWait());
		
	}

	IEnumerator moveLeftTopAndWait(){
		
		var pointA = transform.position;
		var pointB = leftTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed/2));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		
		yield return new WaitForSeconds(1.2f);
		StartCoroutine (moveLeftBottomAndWait());
		
	}

	IEnumerator moveLeftBottomAndWait(){
		
		var pointA = transform.position;
		var pointB = leftBottomPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		StartCoroutine (pattern());
		yield return new WaitForSeconds(3.5f);
		StartCoroutine (moveLeftTopAndWait2());
		
	}

	IEnumerator moveLeftTopAndWait2(){
		
		var pointA = transform.position;
		var pointB = leftTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		
		yield return new WaitForSeconds(1.2f);
		StartCoroutine (moveToBeginning());
		
	}

	IEnumerator moveToBeginning(){
		
		var pointA = transform.position;
		var pointB = rightTopPosition;
		
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed));
		
		Vector3 point = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//transform.position = new Vector3 (112, 3, -9);
		
		yield return new WaitForSeconds(3.5f);
		StartCoroutine (waitAtBeginning());
		
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
	void OnTriggerEnter2D(Collider2D collider){
		
		
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
		
	}
	private void onHit()
	{
		health -= 20;
		StartCoroutine (Blink ());
	}
	IEnumerator Blink(){
		foreach (Transform child in transform) {                                                                                                                                                             
			
			foreach (Transform chilchild in child.transform){
				foreach (Transform chilchilchild in chilchild.transform){
				chilchilchild.gameObject.GetComponent<Renderer> ().enabled = false;
				chilchild.gameObject.GetComponent<Renderer> ().enabled = false;
				child.gameObject.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (0.01f);
				chilchilchild.gameObject.GetComponent<Renderer>().enabled=true;
				chilchild.gameObject.GetComponent<Renderer> ().enabled = true;
				child.gameObject.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (0.01f);
				}
			}
		}
	}

	IEnumerator pattern(){
		shootPlayer ();
		yield return new WaitForSeconds(0.5f);
		shootPlayer ();
		yield return new WaitForSeconds(0.5f);
		//spawnSpiders ();
		//yield return new WaitForSeconds(0.5f);
		shootPlayer ();
		yield return new WaitForSeconds(0.5f);
		shootPlayer ();
		yield return new WaitForSeconds(0.5f);
		shootPlayer ();
		yield return new WaitForSeconds(0.5f);
	}
	void shootPlayer(){
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y-1.5f, transform.position.z);
		bullet = Instantiate (projectileStraight,pos , transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D> ().velocity = (player.transform.position - transform.position).normalized*7;
		Destroy(bullet.gameObject, distance);

	}
	void spawnSpiders(){
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y-1.5f, transform.position.z);
		spiderspawn = Instantiate (spider,pos , transform.rotation) as GameObject;
		spiderspawn.transform.localEulerAngles.Set(0,0,270);
		spiderspawn.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(0, 0));

	}
}
