using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimer : MonoBehaviour {


	private Slider slider;

	private GameObject player;

	private float airBurnRate = 1f;

	public float air = 100f;

	void Awake() {
		GetReferences();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!player) {
			return;
		}



		if (air > 0) {

			// decrement air
			air -= airBurnRate * Time.deltaTime;
			slider.value = air;

		} else {


			GetComponent<GameplayController>().PlayerDied();
			Destroy(player);
		}


	}


	void GetReferences ()
	{

		// find all the game objects
		player = GameObject.Find("Player");
		slider = GameObject.Find("Air Slider Bar").GetComponent<Slider>();

		if (!slider) {
			Debug.Log("No Air slider found");
		}


		// init the slider
		slider.minValue = 0f;
		slider.maxValue = air;
		slider.value = slider.maxValue;

	}

}
