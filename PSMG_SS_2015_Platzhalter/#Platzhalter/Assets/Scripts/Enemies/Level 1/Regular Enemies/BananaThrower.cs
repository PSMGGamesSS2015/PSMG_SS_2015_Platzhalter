using UnityEngine;
using System.Collections;

public class BananaThrower : MonoBehaviour {

	private float speed = -6f;
	private float vertical = 10f;
	private float health = 30f;
	public GameObject projectile;
	private GameObject bullet;
	private float distance;

	// Use this for initialization
	void Start () {
		InvokeRepeating("fire", 1.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		checkHealth ();
	}
	private void fire(){
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, vertical));
		Destroy(bullet.gameObject, 3f);
	}
	private void checkHealth()
	{
		if (health <= 0)
		{
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
			
		}
	}
	
	private void onHit()
	{
		Debug.Log ("MonkeyHIT");
		health -= 10; 
	}
	
	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
	}
}
