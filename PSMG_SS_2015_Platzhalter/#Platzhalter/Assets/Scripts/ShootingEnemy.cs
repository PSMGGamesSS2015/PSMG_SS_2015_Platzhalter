using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShootingEnemy : MonoBehaviour {

	private float speed = -25f;
	private float vertical = 0f;
	private float damage = 10;
	public GameObject projectile;
	public AudioSource shootSound;
	private int weapon;
	private GameObject bullet;
	private GameObject bullet_weapon2_1,bullet_weapon2_2;
	private float distance;

	public GameObject ui_controller;
	

	// Use this for initialization
	void Start () {

		InvokeRepeating("fire", 2, 2);
			
	}
	
	// Update is called once per frame
	void Update () {

			
	}

	private void fire(){
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector2(speed, vertical));
		shootSound.Play ();
		Destroy (bullet.gameObject, 1);
	}

}
