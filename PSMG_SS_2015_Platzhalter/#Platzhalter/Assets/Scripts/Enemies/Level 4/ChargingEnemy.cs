using UnityEngine;
using System.Collections;

public class ChargingEnemy : MonoBehaviour {

	private float health = 30;
	
	private GameObject item;
	private GameObject healthUp;
	
	// Use this for initialization
	void Start () {
		healthUp = GameObject.Find ("HealthUp");
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
			if (i == 1)
			{
				item = Instantiate(healthUp, transform.position,  Quaternion.identity) as GameObject;
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

