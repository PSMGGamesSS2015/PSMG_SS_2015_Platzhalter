using UnityEngine;
using System.Collections;

public class PatrolingEnemyScript : MonoBehaviour {
	
	public float moveSpeed;
	private int health;
	
	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0) {
			Destroy(this.gameObject);
		}
		transform.Translate (new Vector3 (moveSpeed, 0, 0) * Time.deltaTime);
		
	}
	

	public void onHit(){
		health -= 20;
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "Box") {
			moveSpeed*=-1;
		}
		else if (collision.tag == "Player") {

			Debug.Log("Playerhit");
			collision.GetComponent<SimplePlatformController>().onHit();
		}

	}
	
}