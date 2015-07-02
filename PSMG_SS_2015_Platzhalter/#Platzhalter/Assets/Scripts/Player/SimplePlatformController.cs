using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XInputDotNetPure;

public class SimplePlatformController : MonoBehaviour {

    private bool facingRight = true;
    private bool jump = false;
	public Animator anim;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    private float jumpForce = 500f;

    public Transform groundCheck;

    public GameObject player;
    public GameObject UIController;

    private bool grounded = true;
    private Rigidbody2D rb2d;

	public AudioSource jumpSound, deathSound;

	private bool god;
	private bool pause;


	private int health;

	// Use this for initialization
	void Start() {
		health = 100;
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
			anim.SetBool("Jump",true);
			jumpSound.Play ();
        }

		//Godmode shenanigans

			if (Input.GetKey (KeyCode.G) && Input.GetKey (KeyCode.LeftShift)) {
				god=true;
				health=100000;
				maxSpeed=25f;
			}
			if (Input.GetButtonDown ("Jump") && god) {
				jump=true;
			}

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Walking", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {

            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
			anim.SetBool("Jump",false);
        }
		if (Input.GetButtonUp ("Horizontal")) {
			anim.SetFloat("Walking",0f);
		}
		if(Input.GetButtonDown("Fire3")){
			if(facingRight){
			rb2d.AddForce(new Vector2(15000f,0f));
			}
			else 
				rb2d.AddForce(new Vector2(-15000f,0f));
			}
    }

    void Flip()
    {
        facingRight = !facingRight;
        GameObject player;
        player = GameObject.Find("PlayerModel");
        player.transform.RotateAround(transform.position, transform.up, 180f);
    }
	public void onHit(){
		health -= 20;
        UIController.GetComponent<UIScript>().update_life(health);
		StartCoroutine (ControllerRumble ());
		if (health <= 0)
        {
			//deathSound.Play();

			Destroy(this.gameObject);
				Application.LoadLevel("Game Over");
			GamePad.SetVibration(0,0,0);
			
        }
	}
	IEnumerator ControllerRumble(){
		GamePad.SetVibration (0, 1f,1f);
		yield return new WaitForSeconds (0.5f);
		GamePad.SetVibration (0, 0, 0);
	}
	void onHeal(){
		if (health < 100) {
			health+=20;
		}
		UIController.GetComponent<UIScript> ().update_life (health);
	}

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "DeathZone")
        {
			deathSound.Play ();

				Application.LoadLevel("Game Over");
			
		}

        if (player.gameObject.tag == "Goal")
        {
			Destroy (GameObject.Find("LevelSelector").gameObject);
            Application.LoadLevel("Level 1 Boss");
        }

        if (player.gameObject.tag == "Enemy" || player.gameObject.tag == "BulletEnemy")
        {
            onHit();        
        }
		if (player.gameObject.tag == "HealthUp") {
			onHeal();
		}
    }
	IEnumerator waitfordeath(){
		yield return new WaitForSeconds(3);
	}

}
