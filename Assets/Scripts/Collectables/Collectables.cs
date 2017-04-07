using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// add to the total collectables count;
		Door.instance.collectablesCount++;

	}


	// Collect the collectables
	void OnTriggerEnter2D (Collider2D collider)
	{
		// if its the player, decrement the total
		if (collider.gameObject.tag == "Player") {

			if (Door.instance != null) {
				Door.instance.DecrementCollectables ();
			}

			// "Collect" the gem by destroying it.
			Destroy(gameObject);

		}

	}


}
