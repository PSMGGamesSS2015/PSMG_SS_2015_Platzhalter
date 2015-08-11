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
    private GameObject item;
    private GameObject healthUp;

	

	// Use this for initialization
	void Start () {
		InvokeRepeating("fire", 2, 2);
		healthUp = GameObject.Find ("HealthUp");
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
            int i = Random.Range(1, 5);

            Debug.Log(i);

            if (i == 1)
            {
                item = Instantiate(healthUp, transform.position, transform.rotation) as GameObject;
            }

            foreach (Transform childTransform in this.transform)
            {
                Destroy(childTransform.gameObject);
            }
            Destroy(this.gameObject);

        }
    }

	private void onHit(int i){
		if (i == 1) {
			health -= 10;
		}
		if (i == 2) {
			health -= 20;
		}
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
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit(1);
		}
		if (collider.gameObject.tag == "Mine")
		{
			onHit(2);
		}
    }

}
