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

    public Shooting shootingScript;

    private bool grounded = true;
    private Rigidbody2D rb2d;

	public AudioSource jumpSound;

	public Image game_over;

	private int health;

	// Use this for initialization
	void Start() {
		health = 100;
        rb2d = GetComponent<Rigidbody2D>();
        shootingScript = GameObject.Find("barrel").GetComponent<Shooting>();
		game_over.enabled = false;
    }
	
	// Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (health <= 0) {
			game_over.enabled=true;
			Destroy (this.gameObject);
		}

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
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
			jumpSound.Play ();
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
        shootingScript.setSpeed(-1);
    }
	public void onHit(){
		health -= 20;
	}
	public void fallingToDeath(){
		health = 0;
	}

}
