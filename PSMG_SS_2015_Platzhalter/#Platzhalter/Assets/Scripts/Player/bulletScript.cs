using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	/*
	 * Script for the bullets of the player, so they disappear after hitting an enemy or a wall
	 */

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Ground") {
			foreach (Transform childTransform in this.transform)
			{
				Destroy(childTransform.gameObject);
			}
			Destroy(this.gameObject);
		}
        if (collider.tag == "Enemy")
        {
            foreach (Transform childTransform in this.transform)
            {
                Destroy(childTransform.gameObject);
            }
            Destroy(this.gameObject);
        }
	}
}
