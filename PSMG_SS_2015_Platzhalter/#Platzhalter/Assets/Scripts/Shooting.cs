using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

    private float speed = 25f;
    private float vertical = 0f;
    private float damage = 10;
    public Rigidbody projectile;
    private Rigidbody instantiatedProjectile;
	public AudioSource shootSound;
	public Image Weapon_1,Weapon_2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector2(speed, vertical));
			shootSound.Play ();

            Destroy(instantiatedProjectile.gameObject, 1);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (vertical == 10f)
            {
                vertical = 0f;
				shootSound.pitch=1f;
				Weapon_1.enabled=true;
				Weapon_2.enabled=false;
            }
            else
            {
                vertical = 10f;
				shootSound.pitch=0.4f;
				Weapon_1.enabled=false;
				Weapon_2.enabled=true;
            }
        }
	
	}

    public void setSpeed(int direction)
    {
        speed = speed * direction;
    }

    void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Debug.Log("Bullet was destroyed");
       }
    }
}
