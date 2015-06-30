using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Shooting : MonoBehaviour {

    private float speed = 25f;
    private float vertical = 0f;
    private float damage = 10;
    private bool facingRight = true;
    public GameObject projectile;
	public GameObject projectile2;
	public AudioSource shootSoundW1,shootSoundW2;
	private int weapon;
	private GameObject bullet;
	private GameObject bullet_weapon2_1,bullet_weapon2_2;
	private float timer;
	private float fireRate=0.3f;

	public GameObject ui_controller;


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
				if(Input.GetButton("Fire1") && timer <=0){
					fireWeaponOne();
					timer = fireRate;
				}


				break;
			case 2:
				if(Input.GetButton("Fire1") && timer <=0){
					fireWeaponTwo();
					timer = fireRate;
				}
				break;
			}

		
        }
		timer -= Time.deltaTime;
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
		bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
        if (facingRight == false)
        {
            bullet.transform.RotateAround(transform.position, transform.up, 180f);
        }
		bullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, vertical));
		shootSoundW1.Play ();
		Destroy (bullet.gameObject, 0.8f);
	}
	private void fireWeaponTwo(){
		bullet_weapon2_1 = Instantiate (projectile2, transform.position, transform.rotation) as GameObject;
		bullet_weapon2_1.transform.RotateAround(transform.position, transform.up, 180f);
		bullet_weapon2_1.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, vertical));
		bullet_weapon2_2 = Instantiate (projectile2, transform.position, transform.rotation) as GameObject;
		bullet_weapon2_1.transform.RotateAround(transform.position, transform.up, 180f);
		bullet_weapon2_2.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(speed, -vertical));
		shootSoundW2.Play ();
	
		Destroy(bullet_weapon2_1.gameObject, 1);
		Destroy(bullet_weapon2_2.gameObject,1);
	}
	private void switchToWeaponOne(){
		weapon=1;
		vertical = 0f;
		ui_controller.GetComponent<UIScript> ().switch_w2_w1 ();
	}
	private void switchToWeaponTwo(){
		weapon=2;
		vertical = 9f;
		ui_controller.GetComponent<UIScript> ().switch_w1_w2 ();
	}


}
