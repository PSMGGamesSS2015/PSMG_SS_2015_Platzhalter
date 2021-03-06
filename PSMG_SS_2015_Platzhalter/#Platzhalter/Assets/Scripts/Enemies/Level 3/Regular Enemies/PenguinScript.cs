﻿using UnityEngine;
using System.Collections;

public class PenguinScript : MonoBehaviour {
	
	public Transform goal;
	public int speed;
	private float health = 20;
	
	private GameObject item;
	private GameObject healthUp;
	// Use this for initialization
	void Start () {
		healthUp = GameObject.Find ("HealthUp");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, goal.position, Time.deltaTime * speed);
		if (transform.position == goal.position) {
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
		}
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
				item = Instantiate(healthUp, transform.position,  Quaternion.identity) as GameObject;
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
			onHit();
		}
	}
}
