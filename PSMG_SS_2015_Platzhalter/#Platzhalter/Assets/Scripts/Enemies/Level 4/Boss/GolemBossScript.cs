using UnityEngine;
using System.Collections;

public class GolemBossScript : MonoBehaviour {

	private float health = 1000;
	private float distance= 8.0f;
	private float speed = -12f;
	private float speed2 = -5f;
	private float vertical = 0f;

	private GameObject item;
	private GameObject star;
	private GameObject player;
	private GameObject bullet;
	public GameObject projectile;
	public GameObject projectile2;

	// Use this for initialization
	void Start () {
		star = GameObject.Find ("EndObject");	
		StartCoroutine (waitAtBeginning());
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {if (health <= 0)
		{
			item = Instantiate(star, new Vector3(-7,19,27),  Quaternion.identity) as GameObject;
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
			
		}
	
	}

	IEnumerator waitAtBeginning(){
		
		yield return new WaitForSeconds(2f);
		StartCoroutine (choseMove());
		
	}

	IEnumerator choseMove(){
		
		yield return new WaitForSeconds(1.5f);
		var number = Random.Range(1,6);

		if (number == 1 || number == 2 || number == 3) {

			yield return StartCoroutine (fireWave1());
			StartCoroutine (choseMove());

		}

		if (number == 4 || number == 5) {

			yield return StartCoroutine (shoot1());
			StartCoroutine (choseMove());

		}

		if (number == 6) {

			yield return StartCoroutine (spawnMinion1());
			StartCoroutine (choseMove());

		}


	}
	IEnumerator fireWave1(){
		
		Debug.Log ("fireWave");
		
		yield return new WaitForSeconds(1f);

		float number2 = Random.Range (1, 4);
		StartCoroutine (fireWave2(number2));
		yield return new WaitForSeconds(1.8f);
		
		number2 = Random.Range (1, 4);
		StartCoroutine (fireWave2(number2));
		yield return new WaitForSeconds(1.8f);
		
		number2 = Random.Range (1, 4);
		StartCoroutine (fireWave2(number2));
			
	}

	IEnumerator fireWave2(float number2){


		yield return new WaitForSeconds(1f);

		if (number2 == 1) {
			bullet = Instantiate (projectile2, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed2, vertical));
			Destroy(bullet.gameObject, distance);
			
			bullet = Instantiate (projectile2, new Vector3(transform.position.x,transform.position.y +5,transform.position.z), transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed2, vertical));
			Destroy(bullet.gameObject, distance);
		}

		if (number2 == 2) {
			bullet = Instantiate (projectile2, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed2, vertical));
			Destroy(bullet.gameObject, distance);
			
			bullet = Instantiate (projectile2, new Vector3(transform.position.x,transform.position.y -2.2f,transform.position.z), transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed2, vertical));
			Destroy(bullet.gameObject, distance);
		}

		if (number2 == 3) {
			bullet = Instantiate (projectile2, new Vector3(transform.position.x,transform.position.y +5,transform.position.z), transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed2, vertical));
			Destroy(bullet.gameObject, distance);
			
			bullet = Instantiate (projectile2, new Vector3(transform.position.x,transform.position.y -2.2f,transform.position.z), transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed2, vertical));
			Destroy(bullet.gameObject, distance);
		}


	}
	IEnumerator shoot1(){
		
		Debug.Log ("shoot");
		yield return new WaitForSeconds (1.5f);
		StartCoroutine (shoot2());
		yield return new WaitForSeconds(1f);
		StartCoroutine (shoot2());
		yield return new WaitForSeconds(1f);
		StartCoroutine (shoot2());
		yield return new WaitForSeconds(1f);
		StartCoroutine (shoot2());
		yield return new WaitForSeconds(1f);

	}

	IEnumerator shoot2(){

		Debug.Log ("shoot");

		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Vector3 posPlayerFixed = new Vector3 (player.transform.position.x, player.transform.position.y+1.5f, player.transform.position.z);
		bullet = Instantiate (projectile,pos , transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D> ().velocity = (posPlayerFixed - transform.position).normalized*8;
		Destroy(bullet.gameObject, distance);

		yield return new WaitForSeconds(0.1f);

	}

	IEnumerator spawnMinion1(){

		yield return new WaitForSeconds(0.1f);

		StartCoroutine (spawnMinion2 ());

	}

	IEnumerator spawnMinion2(){

		Debug.Log ("spawn");

		yield return new WaitForSeconds(1f);

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
}
