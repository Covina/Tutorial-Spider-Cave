using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour {


	public GameObject player;

	private float offsetY = 1.5f;
	private float baseCameraSize;

	private float playerStartY;

	private float minX = -0.5f, maxX = 130f;

	// Use this for initialization
	void Start () {

		baseCameraSize = Camera.main.orthographicSize;

		Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, -10);

		playerStartY = player.transform.position.y;

	}
	
	// Update is called once per frame
	void Update ()
	{

		// Check if player still alive
		if (player != null) {

			// check on the bounding box to stop moving the camera after going too far left.
			if (player.transform.position.x > minX && player.transform.position.x < maxX) {


				// set camera out but focused on the player
				Camera.main.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + offsetY, -10);


				// calculate how high we are
				float playerPosY = player.transform.position.y;

				// is the player moving higher?
				if (playerPosY > playerStartY) {

					// widen the camera if so
					Camera.main.orthographicSize = baseCameraSize + Mathf.Abs (playerPosY - playerStartY) / 2;

				} else {

					// set camera back to size
					Camera.main.orthographicSize = baseCameraSize;

				}

			}
		}

	}
}
