using UnityEngine;
using System.Collections;

public class MonkeyEnemy : MonoBehaviour {
	private float health = 30f;
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
