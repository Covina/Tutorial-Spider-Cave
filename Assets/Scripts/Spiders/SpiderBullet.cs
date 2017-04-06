using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D collider)
	{

		// bullet hits the player
		if (collider.gameObject.tag == "Player") {

			Destroy(collider.gameObject);
			Destroy(gameObject);

		}

		// bullet hits the ground
		if (collider.gameObject.tag == "Ground") {

			Destroy(gameObject);

		}


	}


}
