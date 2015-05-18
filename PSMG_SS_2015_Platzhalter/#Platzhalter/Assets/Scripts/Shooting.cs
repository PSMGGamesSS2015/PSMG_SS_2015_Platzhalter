using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    private float speed = 25f;
    private float vertical = 0f;
    private float damage = 10;
    public Rigidbody projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector2(speed, vertical));

            Destroy(instantiatedProjectile.gameObject, 1);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (vertical == 10f)
            {
                vertical = 0f;
            }
            else
            {
                vertical = 10f;
            }
        }
	
	}

    public void setSpeed(int direction)
    {
        speed = speed * direction;
    }
}
