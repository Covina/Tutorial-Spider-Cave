using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour {


	public float forceY = 300f;

	private Rigidbody2D rigidBody;
	private Animator animator;



	void Awake() 
	{
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

	}



	// Use this for initialization
	void Start () {

		StartCoroutine( Attack() );

	}
	

	IEnumerator Attack ()
	{
		yield return new WaitForSeconds( Random.Range(2,7) );

		// Generate random height for jump attack
		forceY = Random.Range(250, 550);

		// apply the upward force
		rigidBody.AddForce( new Vector2(0, forceY) );

		// play the attack animation
		animator.SetBool("IsJumping", true);

		// Wait for animation to complete
		yield return new WaitForSeconds(0.7f);

		// Start it over
		StartCoroutine( Attack() );


	}


	void OnTriggerEnter2D (Collider2D collider)
	{

		if (collider.gameObject.tag == "Ground") {
			// if we landed on the ground, no longer attack
			animator.SetBool("IsJumping", false);
		}

		// did we run into the player?
		if (collider.gameObject.tag == "Player") {

			// destroy player
			Destroy(collider.gameObject);
			GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();

		}

	}





} // SpiderJumper
