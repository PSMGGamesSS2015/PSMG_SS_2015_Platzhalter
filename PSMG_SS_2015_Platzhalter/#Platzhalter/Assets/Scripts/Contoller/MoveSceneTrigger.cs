using UnityEngine;
using System.Collections;

public class MoveSceneTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider newLevel)
    {
        Debug.Log("Hallo");
        if (newLevel.gameObject.tag == "Player")
        {
            Application.LoadLevel("NewScene");
        }
    }
}
