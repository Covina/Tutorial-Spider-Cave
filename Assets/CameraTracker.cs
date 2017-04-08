using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour {


	public GameObject player;

	private float offsetY = 1.5f;

	// Use this for initialization
	void Start () {

		Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, -10);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, -10);

	}
}
