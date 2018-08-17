using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("left")) {
			transform.Translate(Time.deltaTime * (-1 * moveSpeed), 0, 0);
		}

		if (Input.GetKey ("right")) {
			transform.Translate(Time.deltaTime * moveSpeed, 0, 0);
		}

		if (Input.GetKey ("up")) {
			transform.Translate(0, Time.deltaTime * moveSpeed, 0);
		}

		if (Input.GetKey ("down")) {
			transform.Translate(0, Time.deltaTime * (-1 * moveSpeed), 0);
		}

		if (Input.GetKey ("space")) {
			print ("space button pressed!");
		}
		
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			this.gameObject.SetActive (false);
			print ("You died!");
		}
	}
}
