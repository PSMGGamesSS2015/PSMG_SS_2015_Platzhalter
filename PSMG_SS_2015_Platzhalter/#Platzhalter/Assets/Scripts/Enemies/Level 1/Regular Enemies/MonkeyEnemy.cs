using UnityEngine;
using System.Collections;

public class MonkeyEnemy : MonoBehaviour {
	private float health = 30f;
    private GameObject item;
    public GameObject healthUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
