using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour {


	[SerializeField] private Transform startPos, endPos;

	private bool collision;

	public float walkSpeed = 1f;

	private Rigidbody2D rigidBody;

	void Awake ()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void FixedUpdate () {

		// move the spider
		Move();
		ChangeDirection ();
	}


	private void Move() 
	{
		// Using local scale X? Not sure why
		rigidBody.velocity = new Vector2(transform.localScale.x, 0) * walkSpeed;

	}


	// detect new collision to change direction
	void ChangeDirection ()
	{

		// send linecast down to see if we've gone over the end and are no longer hitting the ground
		collision = Physics2D.Linecast (startPos.position, endPos.position, 1 << LayerMask.NameToLayer ("Ground"));

		// draw a line from the spider to the child for debugging
		Debug.DrawLine(startPos.position, endPos.position, Color.green);

		// if we are no longer colliding with the ground, turn around
		if (!collision) {

			Vector3 temp = transform.localScale;

			// change direction on local scale
			if (temp.x == 1) {
				temp.x = -1;
			} else {
				temp.x = 1;
			}

			// turn around
			transform.localScale = temp;
			
		}

	}

	// Kill the player if we run into him
	void OnCollisionEnter2D (Collision2D collider)
	{

		if (collider.gameObject.tag == "Player") {
			
			Destroy(collider.gameObject);
			GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();

		}


	}

}
