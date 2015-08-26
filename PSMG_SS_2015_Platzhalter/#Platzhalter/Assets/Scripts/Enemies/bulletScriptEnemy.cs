﻿using UnityEngine;
using System.Collections;

public class bulletScriptEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
