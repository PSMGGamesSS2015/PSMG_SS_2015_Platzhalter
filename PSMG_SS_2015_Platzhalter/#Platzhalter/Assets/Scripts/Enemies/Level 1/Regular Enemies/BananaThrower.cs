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

	}
	private void fire(){
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-6,-8), Random.Range(10f,14f)));
		Destroy(bullet.gameObject, 3f);
	}

}
