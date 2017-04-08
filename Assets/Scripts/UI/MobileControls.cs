using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MobileControls : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {


	private Player player;


	void Awake()
	{
		player = GameObject.Find("Player").GetComponent<Player>();

	}

	// built in to detect on press
	public void OnPointerDown (PointerEventData eventData)
	{

		if (gameObject.name == "MoveLeft Button") {
			player.SetMoveLeft (true);
		} else if (gameObject.name == "MoveRight Button") {
			player.SetMoveLeft (false);
		} 

	}

	// built in to detect on release
	public void OnPointerUp (PointerEventData eventData)
	{
		player.StopMoving();

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
