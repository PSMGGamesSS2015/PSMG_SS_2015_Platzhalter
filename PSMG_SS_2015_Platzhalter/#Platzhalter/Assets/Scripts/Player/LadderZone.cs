using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

	/*
	 * Script for the ladders of the game. handling the movement of the player when hes in the ladder zone is done by the SimplePlatformController.cs
	 */

	private SimplePlatformController player;
	void Start () 
	{
		player = FindObjectOfType<SimplePlatformController>();
	}

	void OnTriggerEnter2D (Collider2D ladder) 
	{
		if (ladder.gameObject.tag == "Player") 
		{
			player.onLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D ladder) 
	{
		if (ladder.gameObject.tag == "Player") 
		{
			player.onLadder = false;
		}
	}


}
