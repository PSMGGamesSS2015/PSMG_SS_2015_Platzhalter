using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XInputDotNetPure;

public class SimplePlatformController : MonoBehaviour {

    private bool facingRight = true;
    public bool jump = false;
	public bool wallJump = false;
	private bool wallJumping = true;
	public Animator anim;
	private bool invincible = false;
	public float moveForce = 365f;
    public float maxSpeed = 5f;
    private float jumpForce = 500f;

	public float climbSpeed = 5f;
	private float climbVelocity;
	private float gravityStore;

    public Transform groundCheck;
	public Transform wallCheck;

    public GameObject player;
    public GameObject UIController;

    public bool grounded = true;
	public bool walled = true;
    private Rigidbody2D rb2d;

	private Vector2 boostSpeed = new Vector2(700,0);
	private float boostCooldown = 0.1f;
	private bool canBoost = true;

	public AudioSource jumpSound, deathSound, lifeSound;

	private bool god;
	private bool pause;
	public bool onLadder;

	private GameObject lvlCheck;
	private GameObject lifes;

	private int health;
	

	// Use this for initialization
	void Start() {

		health = 100;
        rb2d = GetComponent<Rigidbody2D>();
		lvlCheck = GameObject.Find ("_GM");
		lifes = GameObject.Find ("PlayerLifes");
		gravityStore = rb2d.gravityScale;

    }
	
	// Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown (KeyCode.F1)){
			Application.LoadLevel("Level 1");
		}
		if(Input.GetKeyDown (KeyCode.F2)){
			Application.LoadLevel("Level 1 Boss");
		}
		if(Input.GetKeyDown (KeyCode.F3)){
			Application.LoadLevel("Level 2");
		}

		UIController.GetComponent<UIScript> ().update_lifes (lifes.GetComponent<LifeScript>().lifes);

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		walled = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if ((Input.GetButtonDown("Jump") && grounded )|| (Input.GetButtonDown("Jump")&&onLadder))
        {
            jump = true;
			anim.SetBool("Jump",true);
			jumpSound.Play ();
        }
		if(Input.GetButtonDown("Jump")&&walled){
			wallJump = true;
			anim.SetBool("Jump",true);
			jumpSound.Play ();
		}
		if (grounded && canBoost && Input.GetButtonDown("Fire3")&&lvlCheck.GetComponent<LevelCheck>().levelOneDone==true) {
			StartCoroutine(Boost(0.3f));
		}

		//Godmode shenanigans

			if (Input.GetKey (KeyCode.G) && Input.GetKey (KeyCode.LeftShift)) {
				god=true;
				health=100000;
				maxSpeed=15f;
			}
			if (Input.GetButtonDown ("Jump") && god) {
				jump=true;
			}
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
        anim.SetFloat("Walking", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

		if (onLadder) {
			rb2d.gravityScale = 0f;
			rb2d.velocity = new Vector2(0,0);

			if (v * rb2d.velocity.y < maxSpeed)
			{
				rb2d.AddForce(Vector2.up * v * moveForce);
			}

			if(jump){
				StartCoroutine(jumpFromLadder());
			}
		}
		if (!onLadder) {
			rb2d.gravityScale = gravityStore;
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
		if (wallJump) {
			if(wallJumping){
			rb2d.AddForce(new Vector2(0f, jumpForce));
			if (facingRight) {
			rb2d.AddForce (new Vector2 (-5f, 3f), ForceMode2D.Impulse);
			}
			else rb2d.AddForce (new Vector2 (5f, 3f), ForceMode2D.Impulse);
			wallJump = false;
			anim.SetBool("Jump",false);
			StartCoroutine(wallJumpingCooldown());
			}
		}
		if (Input.GetButtonUp ("Horizontal")) {
			anim.SetFloat("Walking",0f);
		}
    }
	IEnumerator jumpFromLadder(){
		onLadder=false;
		yield return new WaitForSeconds (1.0f);
	}
	IEnumerator Boost(float boostDur)
	{
		float time = 0;
		canBoost = false;
		while (boostDur > time) {
			time += Time.deltaTime;
			if(facingRight)
			{
				rb2d.AddForce(boostSpeed);
			}
			else
			{
				rb2d.AddForce(-boostSpeed);
			}
			yield return 0;
		}
		yield return new WaitForSeconds (boostCooldown);
		canBoost = true;
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
		/*if (facingRight) {
			rb2d.AddForce (new Vector2 (-5f, 3f), ForceMode2D.Impulse);
		}
		else rb2d.AddForce (new Vector2 (5f, 3f), ForceMode2D.Impulse);
		*/
		StartCoroutine (Blink ());
		if (health <= 0)
        {
			//deathSound.Play();
			onDeath();
        }
	}
	void onDeath(){
		Destroy(this.gameObject);
		Application.LoadLevel("Game Over");
		lifes.GetComponent<LifeScript> ().lifes -= 1;
		GamePad.SetVibration(0,0,0);
	}
	IEnumerator Blink(){
		GameObject model = GameObject.Find ("Cube.001");
		for (int i = 0; i<=3; i++) {                                                                                                                                                                              
			model.GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (0.05f);
			model.GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (0.05f);
		}
	}
	IEnumerator ControllerRumble(){
		GamePad.SetVibration (0, 1f,1f);
		yield return new WaitForSeconds (0.4f);
		GamePad.SetVibration (0, 0, 0);
	}
	void onHeal(){
		if (health < 100) {
			health+=20;
		}
		lifeSound.Play ();
		UIController.GetComponent<UIScript> ().update_life (health);
	}

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "DeathZone")
        {
			onDeath ();
		}
        if (player.gameObject.tag == "Enemy" || player.gameObject.tag == "BulletEnemy")
        {
			if (!invincible)
			{
            	onHit();        
				StartCoroutine(invincibility());
			}
		}
		if (player.gameObject.tag == "HealthUp") {
			onHeal();
		}
    }
	IEnumerator invincibility(){
		invincible=true;
		yield return new WaitForSeconds (0.6f);
		invincible=false;
	}
	IEnumerator wallJumpingCooldown(){
		wallJumping = false;
		yield return new WaitForSeconds (1.6f);
		wallJumping=true;
	}
	IEnumerator waitforfade(float fadeTime){
		yield return new WaitForSeconds(fadeTime);
	}
	void OnCollisionEnter2D(Collision2D collider){
		if (collider.transform.tag == "Platform") {
			transform.parent = collider.transform;
		}
	}
	void OnCollisionExit2D(Collision2D collider){
		if (collider.transform.tag == "Platform") {
			transform.parent =null;
		}
	}
}
