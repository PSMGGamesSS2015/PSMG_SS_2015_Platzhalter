using UnityEngine;
using System.Collections;

public class SnakeScript : MonoBehaviour {

	private float moveSpeed = -3f;
	private float health = 50f;
	
	private GameObject item;
	private GameObject healthUp;
	private GameObject model;


	// Use this for initialization
	void Start () {
		healthUp = GameObject.Find ("HealthUp");
		model = GameObject.Find ("SchlangeModel");
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
				item = Instantiate(healthUp,new Vector3(transform.position.x,transform.position.y,2.3f), transform.rotation) as GameObject;
			}
			
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
			if(moveSpeed>0){

				foreach (Transform child in this.transform)
				{
					child.gameObject.transform.localEulerAngles = new Vector3(270,270,0);
				}
			}
			if(moveSpeed<0){
				foreach (Transform child in this.transform)
				{
				child.gameObject.transform.localEulerAngles = new Vector3(270,90,0);
				}
			}
		}
		
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
	}
}
