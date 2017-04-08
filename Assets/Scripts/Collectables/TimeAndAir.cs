using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAir : MonoBehaviour {




	void OnTriggerEnter2D (Collider2D collider)
	{

		Debug.Log("Collision detected with " + collider.name);

		if (collider.gameObject.tag == "Player") {


			if (gameObject.name == "Air_Collectable") {

				GameObject.Find("Gameplay Controller").GetComponent<AirTimer>().air += 15f;

			}

			if (gameObject.name == "Time_Collectable") {

				GameObject.Find("Gameplay Controller").GetComponent<LevelTimer>().time += 15f;

			}


			Destroy(gameObject);


		}


	}



}
