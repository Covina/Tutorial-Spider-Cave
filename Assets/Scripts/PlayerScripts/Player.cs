using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float moveForce = 20f;
	public float jumpForce = 700f;
	public float maxVelocity = 4f;

	// are we standing on the ground
	private bool grounded = true;

	private Rigidbody2D rigidBody;
	private Animator animator;


	void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D>();

		animator = GetComponent<Animator>();
	}


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// walk the player
		PlayerWalkKeyboard ();
	}


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




}
