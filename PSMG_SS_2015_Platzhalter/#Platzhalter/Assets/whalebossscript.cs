using UnityEngine;
using System.Collections;

public class whalebossscript : MonoBehaviour {

	public Vector3 rightPosition;
	public Vector3 leftPosition;
	private float health = 400;
	private GameObject item;
	private GameObject star;
	private GameObject player;
	private GameObject bullet;
	public GameObject projectile;
	// Use this for initialization
	void Start () {
		rightPosition = new Vector3 (9, 3, 4); //rot: 0,0,290
		leftPosition = new Vector3 (-4.5f, 3, 4); //rot: 0,180,290
		star = GameObject.Find ("EndObject");
		StartCoroutine (waitAtBeginning());
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			item = Instantiate(star, new Vector3(-5,7,0),  Quaternion.identity) as GameObject;
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
			
		}
	}
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
	void OnTriggerEnter2D(Collider2D collider){
		
		
		if (collider.gameObject.tag == "BulletPlayer")
		{
			onHit();
		}
		
	}
	private void onHit()
	{
		health -= 20;
		StartCoroutine (Blink ());
	}
	IEnumerator Blink(){
		foreach (Transform child in transform) {                                                                                                                                                            
			foreach (Transform chilchild in child.transform){
					chilchild.gameObject.GetComponent<Renderer> ().enabled = false;
					child.gameObject.GetComponent<Renderer> ().enabled = false;
					yield return new WaitForSeconds (0.01f);
					chilchild.gameObject.GetComponent<Renderer> ().enabled = true;
					child.gameObject.GetComponent<Renderer> ().enabled = true;
					yield return new WaitForSeconds (0.01f);

			}
		}
	}
	IEnumerator waitAtBeginning(){
		
		yield return new WaitForSeconds(1f);
		StartCoroutine (shootLeft());
		yield return new WaitForSeconds(1f);
		StartCoroutine (rotate ());
		
	}
	IEnumerator rotate(){

	}
	IEnumerator shootLeft(){
		Vector3 pos = new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z);
		bullet = Instantiate (projectile, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-4,-8), 12));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectile, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-4,-8), 15));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (projectile, pos, transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-4,-8), 18));
		Destroy(bullet.gameObject, 3f);
	}
}
