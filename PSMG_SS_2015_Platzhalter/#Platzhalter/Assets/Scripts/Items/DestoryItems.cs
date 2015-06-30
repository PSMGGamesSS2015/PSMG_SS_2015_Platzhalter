using UnityEngine;
using System.Collections;

public class DestoryItems : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void destroyItem()
    {
        foreach (Transform childTransform in this.transform)
        {
            Destroy(childTransform.gameObject);
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            destroyItem();
        }
    }
}
