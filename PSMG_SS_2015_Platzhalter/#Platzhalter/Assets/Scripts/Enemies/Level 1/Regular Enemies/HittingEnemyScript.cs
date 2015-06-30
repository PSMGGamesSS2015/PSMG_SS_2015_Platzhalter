using UnityEngine;
using System.Collections;

public class HittingEnemyScript : MonoBehaviour {

	private float moveSpeed = 3;
    private float health = 50;
    private GameObject item;
    private GameObject healthUp;

	// Use this for initialization
	void Start () {
		healthUp = GameObject.Find ("HealthUp");
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);

        checkHealth();
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

    private void onHit()
    {
        health -= 20;
    }

	void OnTriggerEnter2D(Collider2D collider){

        if (collider.tag == "Box")
        {
            moveSpeed *= -1;
        }

        if (collider.gameObject.tag == "BulletPlayer")
        {
            onHit();
        }

    }
	
}

