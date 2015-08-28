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
	public bool platformed = false;
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
	

	void Start() {
		
		health = 100;
		rb2d = GetComponent<Rigidbody2D>();
		lvlCheck = GameObject.Find ("_GM");
		lifes = GameObject.Find ("PlayerLifes");
		gravityStore = rb2d.gravityScale;
		
	}

	void Update()
	{

		// Cheats
		if(Input.GetKeyDown (KeyCode.F1)){
			Application.LoadLevel("Level 1");
		}
		if(Input.GetKeyDown (KeyCode.F2)){
			Application.LoadLevel("Level 1 Boss");
		}
		if(Input.GetKeyDown (KeyCode.F3)){
			Application.LoadLevel("Level 2");
		}
		if(Input.GetKeyDown (KeyCode.F4)){
			Application.LoadLevel("Level 2 Boss");
		}
		if(Input.GetKeyDown (KeyCode.F5)){
			Application.LoadLevel("Level 3");
		}
		if(Input.GetKeyDown (KeyCode.F6)){
			Application.LoadLevel("Level 3 Boss");
		}
		if(Input.GetKeyDown (KeyCode.F7)){
			Application.LoadLevel("Level 4");
		}
		if(Input.GetKeyDown (KeyCode.F8)){
			Application.LoadLevel("Level 4 Boss");
		}

		//calling the update lifes method so the UI is always up to date
		UIController.GetComponent<UIScript> ().update_lifes (lifes.GetComponent<LifeScript>().lifes);
		
		//linecast used for checking if the player can jump/walljump. used below
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		platformed = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform"));
		walled = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		//checks if the player can jump, and sets jump to true. what happens then is coded below
		if ((Input.GetButtonDown("Jump") && grounded )|| (Input.GetButtonDown("Jump")&&onLadder) || (Input.GetButtonDown("Jump")&& platformed))
		{
			jump = true;
			anim.SetBool("Jump",true);
			jumpSound.Play ();
		}

		//walljump
		if(Input.GetButtonDown("Jump")&&walled){
			wallJump = true;
			anim.SetBool("Jump",true);
			jumpSound.Play ();
		}

		//dashing
		if ((grounded || platformed) && canBoost && Input.GetButtonDown("Fire3")&&lvlCheck.GetComponent<LevelCheck>().levelOneDone==true) {
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
		//basic movement
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
		if (h > 0 && !facingRight)
		{
			Flip();
		}
		else if (h < 0 && facingRight)
		{
			Flip();
		}
		if (Input.GetButtonUp ("Horizontal")) {
			anim.SetFloat("Walking",0f);
		}

		//movement on the ladder and after leaving it
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

		//jumping
		if (jump)
		{
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
			anim.SetBool("Jump",false);
		}

		//walljump
		if (wallJump&&lvlCheck.GetComponent<LevelCheck>().levelThreeDone==true) {
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
	}

	//timer, so the player cant jump again after a short time after jumping off a ladder
	IEnumerator jumpFromLadder(){
		onLadder=false;
		yield return new WaitForSeconds (1.0f);
	}

	//dashing. the player has a burst of movement for a short while
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

	//what happens after the player is being hit
	public void onHit(){
		health -= 20;
		UIController.GetComponent<UIScript>().update_life(health);
		StartCoroutine (ControllerRumble ());
		StartCoroutine (Blink ());
		if (health <= 0)
		{
			onDeath();
		}
	}

	//what happens after the player dies
	void onDeath(){
		Destroy(this.gameObject);
		Application.LoadLevel("Game Over");
		lifes.GetComponent<LifeScript> ().lifes -= 1;
		GamePad.SetVibration(0,0,0);
	}

	//player blinks after being hit, for better feedback
	IEnumerator Blink(){
		GameObject model = GameObject.Find ("Cube.001");
		for (int i = 0; i<=3; i++) {                                                                                                                                                                              
			model.GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (0.05f);
			model.GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (0.05f);
		}
	}

	//after being hit, the controller rumbles for a short time
	IEnumerator ControllerRumble(){
		GamePad.SetVibration (0, 1f,1f);
		yield return new WaitForSeconds (0.4f);
		GamePad.SetVibration (0, 0, 0);
	}

	//after picking up the healthup, the player gets 20 life back
	void onHeal(){
		if (health < 100) {
			health+=20;
		}
		lifeSound.Play ();
		UIController.GetComponent<UIScript> ().update_life (health);
	}

	//for colliding with gameobjects
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

	//invincibility frame
	IEnumerator invincibility(){
		invincible=true;
		yield return new WaitForSeconds (0.6f);
		invincible=false;
	}
	//cooldown for the walljump
	IEnumerator wallJumpingCooldown(){
		wallJumping = false;
		yield return new WaitForSeconds (1.6f);
		wallJumping=true;
	}

	//methods so the player sticks to moving platforms
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
