using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private float speed = 25;
    public Rigidbody projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector2(speed, 0f));

            Destroy(instantiatedProjectile.gameObject, 1);
        }
	
	}

    public void setSpeed(int direction)
    {
        speed = speed * direction;
    }
}
