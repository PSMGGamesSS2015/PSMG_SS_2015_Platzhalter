using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

    private float speed = 25f;
    private float vertical = 0f;
    private float damage = 10;
    public Rigidbody projectile;
	private Rigidbody instantiatedProjectile, instantiatedProjectile2;
	public AudioSource shootSound;
	public Image Weapon_1,Weapon_2;
	private int weapon;

	// Use this for initialization
	void Start () {
		weapon = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
			switch(weapon){
			case 1:
				fireWeaponOne();
				break;
			case 2:
				fireWeaponTwo();
				break;
			}


        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (weapon==2)
            {
				switchToWeaponOne();
            }
            else if(weapon==1)
            {
				switchToWeaponTwo();
            }
        }
	
	}
	private void fireWeaponOne(){
		instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
		instantiatedProjectile.velocity = transform.TransformDirection(new Vector2(speed, vertical));
		shootSound.Play ();

		Destroy(instantiatedProjectile.gameObject, 1);
	}
	private void fireWeaponTwo(){
		instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
		instantiatedProjectile2 = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
		instantiatedProjectile.velocity = transform.TransformDirection(new Vector2(speed, vertical));
		instantiatedProjectile2.velocity =transform.TransformDirection (new Vector2(speed,-vertical));
		shootSound.Play ();
	
		Destroy(instantiatedProjectile.gameObject, 1);
		Destroy(instantiatedProjectile2.gameObject,1);
	}
	private void switchToWeaponOne(){
		weapon=1;
		vertical = 0f;
		shootSound.pitch=1f;
		Weapon_1.enabled=true;
		Weapon_2.enabled=false;
	}
	private void switchToWeaponTwo(){
		weapon=2;
		vertical = 9f;
		shootSound.pitch=0.4f;
		Weapon_1.enabled=false;
		Weapon_2.enabled=true;
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
