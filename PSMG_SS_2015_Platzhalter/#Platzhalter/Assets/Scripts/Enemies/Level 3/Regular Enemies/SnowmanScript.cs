using UnityEngine;
using System.Collections;

public class SnowmanScript : MonoBehaviour {
	
	public GameObject proj;
	private GameObject bullet;
	private GameObject player;
	public int speed;

	private float health = 20;
	private float distance = 2.5f;
	private GameObject item;
	private GameObject healthUp;
	
	void Start () {
		healthUp = GameObject.Find ("HealthUp");
		player = GameObject.Find ("Player");
		InvokeRepeating("fire", 2.5f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		checkHealth();
		
	}
	private void fire(){
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y+0.5f, transform.position.z);
		bullet = Instantiate (proj,pos,transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D> ().velocity = (player.transform.position - transform.position).normalized*speed;
		Destroy(bullet.gameObject, distance);
	}

	private void checkHealth()
	{
		if (health <= 0) {
			int i = Random.Range (1, 5);
			if (i == 1) {
				item = Instantiate (healthUp, transform.position, Quaternion.identity) as GameObject;
			}
			
			foreach (Transform childTransform in this.transform) {
				Destroy (childTransform.gameObject);
			}
			Destroy (this.gameObject);
			
		}
	}
	private void onHit(){
		health -= 10;
		StartCoroutine (Blink ());
	}
	IEnumerator Blink(){
		foreach (Transform child in transform) {                                                                                                                                                             
			foreach (Transform chilchild in child.transform){
				chilchild.gameObject.GetComponent<Renderer> ().enabled = false;
				yield return new WaitForSeconds (0.02f);
				chilchild.gameObject.GetComponent<Renderer> ().enabled = true;
				yield return new WaitForSeconds (0.02f);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
	}
}
