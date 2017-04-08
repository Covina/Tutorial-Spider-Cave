using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour {


	[SerializeField] private GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine( Attack() );
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator Attack ()
	{
		yield return new WaitForSeconds(Random.Range(2,7));

		// spawn bullet
		Instantiate(bulletPrefab, transform.position, Quaternion.identity);

		StartCoroutine( Attack() );
	}


	// Player and Spider collide
	void OnCollisionEnter2D (Collision2D collider)
	{

		if (collider.gameObject.tag == "Player") {

			Destroy(collider.gameObject);

		}


	}


}
