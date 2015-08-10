using UnityEngine;
using System.Collections;

public class SpittingSpider : MonoBehaviour {

	public float moveSpeed = -2f;
	private float health = 30f;
	private float speed = -25f;
	private float vertical = 0f;
	public GameObject projectile;
	private GameObject bullet;
	private float distance= 0.7f;
	private GameObject item;
	private GameObject healthUp;
	
	
	// Use this for initialization
	void Start () {
		healthUp = GameObject.Find ("HealthUp");

		InvokeRepeating("fire", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, moveSpeed, 0) * Time.deltaTime);
		
		checkHealth();
	}
	private void fire(){
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, vertical));
		Destroy(bullet.gameObject, distance);
	}
	private void checkHealth()
	{
		if (health <= 0)
		{
			int i = Random.Range(1, 5);
			
			Debug.Log(i);
			
			if (i == 1)
			{
				item = Instantiate(healthUp, new Vector3(transform.position.x,transform.position.y,2.3f), Quaternion.identity) as GameObject;
			}
			
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
			
		}
	}
	
	private void onHit(){
		health -= 10;
		StartCoroutine (Blink ());
	}
	IEnumerator Blink(){
		foreach (Transform child in transform) {                                                                                                                                                             
			child.gameObject.GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (0.02f);
			child.gameObject.GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (0.02f);
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Box") {
			moveSpeed*=-1;
			if(moveSpeed<0){
				foreach (Transform child in transform)
				{
					child.gameObject.transform.localEulerAngles = new Vector3(90,255,180);
				}
			}
			else if(moveSpeed>0){
				foreach(Transform child in transform){
					child.gameObject.transform.localEulerAngles = new Vector3(270,255,0);
				}

			}
		}
		
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
	}
}
