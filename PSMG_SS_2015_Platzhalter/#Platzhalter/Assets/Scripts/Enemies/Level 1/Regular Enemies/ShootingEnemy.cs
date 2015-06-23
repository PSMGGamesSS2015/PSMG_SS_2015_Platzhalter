using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShootingEnemy : MonoBehaviour {

	private float speed = -25f;
	private float vertical = 0f;
    private float health = 30f;
	public GameObject projectile;
	private GameObject bullet;
	private float distance= 0.7f;

	

	// Use this for initialization
	void Start () {
		InvokeRepeating("fire", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {

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
            foreach (Transform childTransform in this.transform)
            {
                Destroy(childTransform.gameObject);
            }
            Destroy(this.gameObject);

        }
    }

    private void onHit()
    {
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
