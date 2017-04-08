using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

	// get the slider
	private Slider slider;

	// get the player so we can kill him if we run out
	private GameObject player;


	// set burn rate
	private float timeBurnRate = 1f;

	// set total time
	public float time = 100f;

	void Awake() {
		GetReferences();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		// if player is dead, end update
		if (!player) {
			return;
		}


		// if time remaining, decrement it
		if (time > 0) {

			// decrement time
			time -= timeBurnRate * Time.deltaTime;
			slider.value = time;

		} else {
			// kill the player, time is out!
			GetComponent<GameplayController>().PlayerDied();
			Destroy(player);
		}


	}


	void GetReferences ()
	{

		// find all the game objects
		player = GameObject.Find ("Player");
		slider = GameObject.Find ("Time Slider Bar").GetComponent<Slider> ();

		if (!slider) {
			Debug.Log("No Time slider found");
		}

		// init the slider
		slider.minValue = 0f;
		slider.maxValue = time;
		slider.value = slider.maxValue;

	}

}
