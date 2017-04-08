using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	private float moveForce = 20f;
	private float jumpForce = 800f;
	private float maxVelocity = 4f;

	// are we standing on the ground
	private bool grounded = true;

	private Rigidbody2D rigidBody;
	private Animator animator;


	private bool moveLeft, moveRight;


	void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D>();

		animator = GetComponent<Animator>();

		GameObject.Find("Jump Button").GetComponent<Button>().onClick.AddListener( () => Jump() );
	}


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// walk the player
		//PlayerWalkKeyboard ();

		PlayerWalkJoystick();
	}



	// MOBILE
	void PlayerWalkJoystick ()
	{
		float forceX = 0f;
		float velocity = Mathf.Abs (rigidBody.velocity.x);

		// MOVE RIGHT
		if (moveRight) {

			// 
			if (velocity < maxVelocity) {

				if (grounded) {
					forceX = moveForce;
				} else {
					// can influence movement while in the air
					forceX = moveForce * 1.1f;
				}

			}


			// face to the right
			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			// play walk animation
			animator.SetBool ("IsWalking", true);

		} else if (moveLeft) {

		// MOVE LEFT

			if (velocity < maxVelocity) {

				if (grounded) {
					forceX = -moveForce;
				} else {
					// can influence movement while in the air
					forceX = -moveForce * 1.1f;
				}

			}

			// face to the right
			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;

			// play walk animation
			animator.SetBool ("IsWalking", true);

		} else {

			animator.SetBool("IsWalking", false);

		}

		// apply the movement
		rigidBody.AddForce(new Vector2(forceX, 0f) );

	}


	// KEYBOARD
	void PlayerWalkKeyboard ()
	{

		float forceX = 0f;
		float forceY = 0f;

		// get the velocity, always positive
		float velocity = Mathf.Abs (rigidBody.velocity.x);

		// get the horizontal input
		float h = Input.GetAxisRaw ("Horizontal");

		// moving to right?
		if (h > 0) {

			// 
			if (velocity < maxVelocity) {

				if (grounded) {
					forceX = moveForce;
				} else {
					// can influence movement while in the air
					forceX = moveForce * 1.1f;
				}

			}


			// face to the right
			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			// play walk animation
			animator.SetBool ("IsWalking", true);

		} else if (h < 0) {

			// Facing left!

			if (velocity < maxVelocity) {

				if (grounded) {
					forceX = -moveForce;
				} else {
					// can influence movement while in the air
					forceX = -moveForce * 1.1f;
				}

			}

			// face to the right
			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;

			// play walk animation
			animator.SetBool ("IsWalking", true);


		} else if (h == 0) {


			// idle state
			animator.SetBool ("IsWalking", false);

		}


		// check for jumping
		if( Input.GetKey(KeyCode.Space) ) {

			if(grounded) {

				// set we're not grounded
				grounded = false;

				// now jump
				forceY = jumpForce;


			}

		}



		// apply the movement
		rigidBody.AddForce(new Vector2(forceX, forceY) );

	}



	void OnCollisionEnter2D (Collision2D collider)
	{

		if (collider.gameObject.tag == "Ground") {

			grounded = true;

		}


	}


	public void BouncePlayer (float force)
	{


		if (grounded) {

			grounded = false;

			rigidBody.AddForce(new Vector2(0, force) );

		}

	}



	public void SetMoveLeft (bool moveLeft)
	{
		this.moveLeft = moveLeft;
		this.moveRight = !moveLeft;
	}


	public void StopMoving()
	{
		this.moveLeft = false;
		this.moveRight = false;
	}

	// jump for mobile controls
	public void Jump()
	{
		if(grounded) {

			// set we're not grounded
			grounded = false;

			// apply the movement
			rigidBody.AddForce(new Vector2(0, jumpForce) );

		}



	}


}
