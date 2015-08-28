using UnityEngine;
using System.Collections;

public class bulletScriptEnemy : MonoBehaviour {

	/**
	 * Script for enemy bullets, so if it hits the player or the ground it disappears
	 */

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player"||collider.tag=="Ground")
        {
            foreach (Transform childTransform in this.transform)
            {
                Destroy(childTransform.gameObject);
            }
            Destroy(this.gameObject);
        }
    
    }
}
