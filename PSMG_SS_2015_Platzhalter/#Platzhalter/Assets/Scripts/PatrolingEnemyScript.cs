using UnityEngine;
using System.Collections;

public class PatrolingEnemyScript : MonoBehaviour {
	
	private float moveSpeed = 3;
	private float health = 50;
	
	// Use this for initialization
	void Start () {
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
            foreach (Transform childTransform in this.transform)
            {
                Destroy(childTransform.gameObject);
            }
            Destroy(this.gameObject);

        }
    }
	
	private void onHit(){
		health -= 10;
	}

	void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.tag == "Box") {
			moveSpeed*=-1;
		}

        if (collider.gameObject.tag == "BulletPlayer")
        {
            onHit();
        }
	}
	
}