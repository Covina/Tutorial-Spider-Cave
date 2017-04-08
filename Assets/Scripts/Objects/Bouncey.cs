using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncey : MonoBehaviour {


	private float force = 1000f;

	private Animator animator;


	void Awake ()
	{
		animator = GetComponent<Animator>();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator AnimateBouncer ()
	{

		animator.Play("Bounce");
		yield return new WaitForSeconds(0.5f);

	}


	void OnTriggerEnter2D (Collider2D collider)
	{

		if (collider.gameObject.tag == "Player") {

			// Launch Upward using function inside Player class
			collider.gameObject.GetComponent<Player>().BouncePlayer(force);
			StartCoroutine( AnimateBouncer() );
		}

	}

}
