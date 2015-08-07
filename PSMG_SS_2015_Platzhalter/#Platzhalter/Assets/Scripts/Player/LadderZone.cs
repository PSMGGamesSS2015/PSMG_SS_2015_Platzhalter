using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

	private SimplePlatformController thePlayer;
	// Use this for initialization
	void Start () 
	{
		thePlayer = FindObjectOfType<SimplePlatformController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D ladder) 
	{
		if (ladder.gameObject.tag == "Player") 
		{
			thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D ladder) 
	{
		if (ladder.gameObject.tag == "Player") 
		{
			thePlayer.onLadder = false;
		}
	}


}
