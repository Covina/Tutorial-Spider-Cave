using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public static Door instance;

	private Animator animator;
	private BoxCollider2D box;

	// accessible from elsewhere, just not needed in inspector
	[HideInInspector] public int collectablesCount;



	void Awake ()
	{
		// create instance of the door
		MakeInstance();

		// Animator
		animator = GetComponent<Animator>();

		// Door Box Collider
		box = GetComponent<BoxCollider2D>();

	}


//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	// Create singleton
	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}

	}

	// Door opener
	IEnumerator OpenDoor ()
	{
		animator.Play("door-open");

		yield return new WaitForSeconds (0.7f);

		// enable that the box collider is a trigger now
		box.isTrigger = true;
		
	}

	// If the door is open and the player walks through it, WIN!
	void OnTriggerEnter2D (Collider2D collider)
	{

		if (collider.gameObject.tag == "Player") {

			// win level
			Debug.Log("Level Completed!");
		}

	}

	// Reduce count of collectables when collected
	public void DecrementCollectables ()
	{
		collectablesCount--;

		// if we've acquired them all, then open the door!
		if (collectablesCount == 0) {

			StartCoroutine( OpenDoor() );

		}

	}




} // Door
