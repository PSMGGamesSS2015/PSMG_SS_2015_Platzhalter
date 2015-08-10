using UnityEngine;
using System.Collections;

public class whalebossscript : MonoBehaviour {

	public Vector3 rightPosition,leftPosition;
	public Vector3 rightFinPos,leftFinPos;
	public Vector3 leftTopPos,rightTopPos;
	private float health = 400;
	private GameObject item;
	private GameObject star;
	private GameObject player;
	private GameObject bullet;
	public GameObject proj;
	public GameObject platformRight,platformLeft,flosse;
	// Use this for initialization
	void Start () {
		leftPosition = new Vector3 (-5.5f, 1f, 3f); //rot: 0,180,290
		rightPosition = new Vector3 (10.75f, 1f, 3f); //rot: 0,0,290
		rightFinPos = new Vector3 (20.5f,-3,2.5f);
		leftFinPos = new Vector3 (-14f,-3,2.5f);
		leftTopPos = new Vector3 (-16, 12, 3);
		rightTopPos = new Vector3 (21, 12, 3);
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
		StartCoroutine (moveRight());

		
	}
	IEnumerator ChooseMove(){
		yield return StartCoroutine (MoveObject (transform, transform.position, new Vector3(transform.position.x,transform.position.y -12f,transform.position.z), 2.0f));
		int rng = Random.Range (0, 5);
		yield return new WaitForSeconds (1f);
		if (rng==0||rng==1) {
			StartCoroutine (moveLeft());
		} else if (rng==2||rng==3) {
			StartCoroutine (moveRight());
		} else if (rng == 4) {
			StartCoroutine (DestroyPlatform());
		}
	}
	IEnumerator moveLeft(){
		Debug.Log ("shootleft");
		yield return new WaitForSeconds (0.1f);
		transform.localEulerAngles = new Vector3 (0,180f,290f);
		yield return StartCoroutine (MoveObject (transform, transform.position, new Vector3(leftPosition.x,leftPosition.y -12f,leftPosition.z), 1.0f));
		yield return StartCoroutine (MoveObject (transform, transform.position, leftPosition, 1.0f));
		yield return StartCoroutine (shootLeft ());
		StartCoroutine (ChooseMove());
	}
	IEnumerator shootLeft(){
		yield return new WaitForSeconds (0.1f);
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-18,-22), -3));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-8,-12), -5));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-23,-26), -5));
		Destroy(bullet.gameObject, 3f);
	}
	IEnumerator moveRight(){
		Debug.Log ("shootright");
		yield return new WaitForSeconds (0.1f);
		transform.localEulerAngles = new Vector3 (0, 0, 290);
		yield return StartCoroutine (MoveObject (transform,transform.position, new Vector3(rightPosition.x,rightPosition.y -12f,rightPosition.z), 1.0f));
		yield return StartCoroutine (MoveObject (transform, transform.position, rightPosition, 1.0f));
		yield return StartCoroutine (shootRight ());
		StartCoroutine (ChooseMove());
	}
	IEnumerator shootRight(){
		yield return new WaitForSeconds (0.1f);
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-18,-22), -3));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-8,-12), -5));
		Destroy(bullet.gameObject, 3f);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-23,-26), -5));
		Destroy(bullet.gameObject, 3f);
	}
	IEnumerator DestroyPlatform(){
		Debug.Log ("destroy");
		int rng = Random.Range (0, 2);
		if (rng == 0) {
			Debug.Log ("destroyright");
			yield return StartCoroutine(DestroyRight());
		} else if (rng == 1) {
			Debug.Log ("destroyleft");
			yield return StartCoroutine(DestroyLeft());
		}
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (ChooseMove());
	}
	IEnumerator DestroyRight(){
		//flosse nimmt sich die Plattform
		Vector3 rightDownPos = new Vector3 (rightFinPos.x, rightFinPos.y - 12f, rightFinPos.z);
		yield return StartCoroutine(MoveObject(flosse.transform,rightDownPos,rightFinPos,1.0f));
		yield return new WaitForSeconds (1.0f);
		StartCoroutine(MoveObject(flosse.transform,rightFinPos,rightDownPos,1.0f));
		StartCoroutine(MoveObject(platformRight.transform,platformRight.transform.position,new Vector3(platformRight.transform.position.x,platformRight.transform.position.y-12f,platformRight.transform.position.z),1.0f));

		//wal springt nach oben
		transform.localEulerAngles = new Vector3 (0, 0, 290);
		yield return new WaitForSeconds (1.5f);
		yield return StartCoroutine (MoveObject(transform,transform.position, new Vector3(rightTopPos.x,rightTopPos.y-22f,rightTopPos.z),0.1f));
		StartCoroutine (shootRightJumping ());
		yield return StartCoroutine (MoveObject (transform, transform.position, rightTopPos, 1.5f));


		//wal dreht sich und fällt ins wasser
		transform.localEulerAngles = new Vector3 (180, 180, 245);
		transform.position= new Vector3(transform.position.x-2f, transform.position.y, transform.position.z);
		yield return StartCoroutine (MoveObject (transform, transform.position,new Vector3(rightTopPos.x,rightTopPos.y-22f,rightTopPos.z), 1.5f));
		StartCoroutine(MoveObject(platformRight.transform,platformRight.transform.position,new Vector3(platformRight.transform.position.x,platformRight.transform.position.y+12f,platformRight.transform.position.z),0.5f));

	}
	IEnumerator shootRightJumping(){
		yield return new WaitForSeconds (0.25f);
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-18,-22), -3));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos1 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos1, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-28,-32), -2));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos2 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos2, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-13,-18), -3));
		Destroy(bullet.gameObject, 3f);
		Vector3 pos3 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos3, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-18,-22), -3));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos4 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos4, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-28,-32), -2));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos5 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos5, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-13,-18), -3));
		Destroy(bullet.gameObject, 3f);
	}
	IEnumerator DestroyLeft(){

		Vector3 leftDownPos = new Vector3 (leftFinPos.x, leftFinPos.y - 12f, leftFinPos.z);
		yield return StartCoroutine(MoveObject(flosse.transform,leftDownPos,leftFinPos,1.0f));
		yield return new WaitForSeconds (1.0f);
		StartCoroutine(MoveObject(flosse.transform,leftFinPos,leftDownPos,1.5f));
		StartCoroutine(MoveObject(platformLeft.transform,platformLeft.transform.position,new Vector3(platformLeft.transform.position.x,platformLeft.transform.position.y-12f,platformLeft.transform.position.z),1.5f));
	
		//wal springt nach oben
		transform.localEulerAngles = new Vector3 (0, 180, 290);
		yield return new WaitForSeconds (1.5f);
		yield return StartCoroutine (MoveObject(transform,transform.position, new Vector3(leftTopPos.x,leftTopPos.y-22f,leftTopPos.z),0.1f));
		StartCoroutine (shootLeftJumping ());
		yield return StartCoroutine (MoveObject (transform, transform.position, leftTopPos, 1.5f));
		
		
		//wal dreht sich und fällt ins wasser
		transform.localEulerAngles = new Vector3 (180, 0, 245);
		transform.position= new Vector3(transform.position.x+2f, transform.position.y, transform.position.z);
		yield return StartCoroutine (MoveObject (transform, transform.position,new Vector3(leftTopPos.x,leftTopPos.y-22f,leftTopPos.z), 1.5f));
		StartCoroutine(MoveObject(platformLeft.transform,platformLeft.transform.position,new Vector3(platformLeft.transform.position.x,platformLeft.transform.position.y+12f,platformLeft.transform.position.z),0.5f));

	}
	IEnumerator shootLeftJumping(){
		yield return new WaitForSeconds (0.1f);
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-18,-22), -3));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos1 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos1, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-8,-12), -5));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos2 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos2, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-23,-26), -5));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos3 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos3, new Quaternion(0,0,200,0)) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-18,-22), -3));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos4 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos4, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-8,-12), -5));
		Destroy(bullet.gameObject, 3f);
		yield return new WaitForSeconds (0.25f);
		Vector3 pos5 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		bullet = Instantiate (proj, pos5, new Quaternion(0,0,200,0)) as GameObject;
		bullet.transform.localEulerAngles.Set (0, 0, 200);
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(Random.Range(-23,-26), -5));
		Destroy(bullet.gameObject, 3f);

	}
}
