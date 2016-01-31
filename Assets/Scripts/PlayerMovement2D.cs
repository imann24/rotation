using UnityEngine;
using System.Collections;

public class PlayerMovement2D : MonoBehaviour {
	public float moveSpeed = 2f;
	public float jumpForce = 200f;
	private Rigidbody2D rb2d;
	public bool frozen = false;

	public LayerMask whatIsGround;  
	private float groundedRadius = .2f; 
	public bool grounded; 
	private Transform groundCheck;
	private bool facingRight = false;
	bool suppressLandSFX = true;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find("GroundCheck");
	}


	void FixedUpdate(){
		if (frozen) {
			rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
			//return here to not flip
		} else {
			rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		}

		float h = Input.GetAxis ("Horizontal");
		bool jump = Input.GetKeyDown (KeyCode.Space);

		if (Physics2D.OverlapCircle (groundCheck.position, groundedRadius, whatIsGround)) {
			grounded = true;
		} else {
			grounded = false;
		}

		if (h < 0 && facingRight) {
			Flip ();
		} else if (h > 0 && !facingRight) {
			Flip ();
		}
		// if grounded can't move in air
		if (grounded) {
			rb2d.velocity = new Vector2 (moveSpeed * h, rb2d.velocity.y);
		}
		if (grounded && jump)
		{

			// Plays the audio event
			EventController.Event("jump");

			// Add a vertical force to the player.
			grounded = false;
			jump = false;
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpForce);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		EventController.Event("hitGround");
	}

	void Flip() {
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale; 
	}
}
