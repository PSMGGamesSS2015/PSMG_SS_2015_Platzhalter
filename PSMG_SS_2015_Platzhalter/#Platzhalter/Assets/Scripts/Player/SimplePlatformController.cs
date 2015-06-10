using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimplePlatformController : MonoBehaviour {

    private bool facingRight = true;
    private bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    private float jumpForce = 500f;

    public Transform groundCheck;

    public GameObject player;
    public GameObject UIController;

    private bool grounded = true;
    private Rigidbody2D rb2d;

	public AudioSource jumpSound;

	private bool god;


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
        //anim.SetFloat("Speed", Mathf.Abs(h));

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
            //anim.SetTrigger("Jump");
			//jumpSound.Play ();
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
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

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Application.LoadLevel("Game Over");
        }
	}
	public void fallingToDeath(){
		health = 0;
	}

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "DeathZone")
        {
            Application.LoadLevel("Game Over");
        }

        if (player.gameObject.tag == "Goal")
        {
            Application.LoadLevel("Level 1 Boss");
        }

        if (player.gameObject.tag == "Enemy" || player.gameObject.tag == "BulletEnemy")
        {
            onHit();        
        }
    }

}
