using UnityEngine;
using System.Collections;

public class GrassHopper : MonoBehaviour {

	private Rigidbody2D rb2d;
	public int jumpForce;
	private GameObject item;
	private GameObject healthUp;
	private float health = 30f;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		jumpLeft_ ();
		healthUp = GameObject.Find ("HealthUp");
	}
	void jumpLeft_(){
		StartCoroutine (jumpLeft ());
	}
	void jumpRight_(){
		StartCoroutine (jumpRight ());
	}
	IEnumerator jumpLeft(){
		transform.localEulerAngles = new Vector3 (0, 0, 0);
		rb2d.AddForce (new Vector2(300f, 400f));
		yield return new WaitForSeconds(2.1f);
		jumpRight_ ();
	}
	IEnumerator jumpRight(){
		transform.localEulerAngles = new Vector3 (0, 180, 0);
		rb2d.AddForce (new Vector2(-300f, 400f));
		yield return new WaitForSeconds(2.1f);
		jumpLeft_ ();
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

		
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
	}
}
