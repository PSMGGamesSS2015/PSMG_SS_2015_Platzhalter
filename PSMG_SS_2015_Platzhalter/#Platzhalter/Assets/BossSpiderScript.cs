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

	private float health = 800;
	private GameObject item;
	//private GameObject star;
	private GameObject player;
	public GameObject projectileStraight;
	private GameObject bullet;
	private float speed = -25f;
	private float distance= 1.3f;


	// Use this for initialization
	void Start () {
		middleBottomPosition = new Vector3 (-7, 7, 0);
		middleTopPosition = new Vector3 (-7, 20, 0);
		rightBottomPosition = new Vector3 (3, 7, 0);
		rightTopPosition = new Vector3 (3, 20, 0);
		leftBottomPosition = new Vector3 (-17, 7, 0);
		leftTopPosition = new Vector3 (-17, 20, 0);
		star = GameObject.Find ("EndObject");
		StartCoroutine (wait ());
		player = GameObject.Find ("Player");
		//star = GameObject.Find ("EndObject");
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			//item = Instantiate(star, new Vector3(117,10,-5),  Quaternion.identity) as GameObject;
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
			
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
	private void onHit()
	{
		health -= 20;
		StartCoroutine (Blink ());
	}
	IEnumerator Blink(){
		foreach (Transform child in transform) {                                                                                                                                                             
			
			foreach (Transform chilchild in child.transform){
				chilchild.gameObject.GetComponent<Renderer> ().enabled = false;
				child.gameObject.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (0.01f);
				chilchild.gameObject.GetComponent<Renderer> ().enabled = true;
				child.gameObject.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (0.01f);
			}
		}
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(1.0f);
		StartCoroutine (patternRight ());

	}
	IEnumerator moveMiddle(){
		MoveObject (transform, rightBottomPosition, rightTopPosition, 0.5f);
		MoveObject (transform, rightTopPosition, middleTopPosition, 0.5f);
		MoveObject (transform, middleTopPosition, middleBottomPosition, 0.5f);
		StartCoroutine (pattern ());
		StartCoroutine (moveLeft ());
	}
	void moveMiddleM(){

	}
	IEnumerator moveLeft(){
		MoveObject (transform, middleBottomPosition, middleTopPosition, 0.5f);
		MoveObject (transform, middleTopPosition, leftTopPosition, 0.5f);
		MoveObject (transform, leftTopPosition, leftBottomPosition, 0.5f);
		StartCoroutine (pattern ());
		StartCoroutine (moveRight ());
	}
	IEnumerator moveRight(){
		MoveObject (transform, leftBottomPosition, leftTopPosition, 0.5f);
		MoveObject (transform, leftTopPosition, rightTopPosition, 0.5f);
		MoveObject (transform, rightTopPosition, rightBottomPosition, 0.5f);
		StartCoroutine (patternRight ());
	}
	IEnumerator patternRight(){
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (pattern ());
		StartCoroutine (moveMiddle ());
	}
	IEnumerator pattern(){
		shootPlayer ();
		yield return new WaitForSeconds(1.0f);
		shootPlayer ();
		yield return new WaitForSeconds(1.0f);
		spawnSpiders ();
		yield return new WaitForSeconds(1.0f);
		shootPlayer ();
		yield return new WaitForSeconds(1.0f);
		shootPlayer ();
		yield return new WaitForSeconds(1.0f);
		shootPlayer ();
		yield return new WaitForSeconds(1.0f);
	}
	void shootPlayer(){
		/*Vector3 pos = new Vector3 (transform.position.x, transform.position.y-1.5f, transform.position.z);
		bullet = Instantiate (projectileStraight,pos , transform.rotation) as GameObject;
		int dir = Vector3.Normalize(this.transform - player.transform);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, dir));
		Destroy(bullet.gameObject, distance);
		*/
	}
	void spawnSpiders(){

	}
}
