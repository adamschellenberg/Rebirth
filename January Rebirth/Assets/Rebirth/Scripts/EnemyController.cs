using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

	public Transform player;
	public float moveSpeed;
	public float minDist;



	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//rotate to look at the player
		transform.LookAt(player.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation


		//move towards the player
		if (Vector3.Distance(transform.position,player.position)>minDist){//move if distance from target is greater than 1
			transform.Translate(new Vector3(moveSpeed* Time.deltaTime,0,0) );
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0);

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			SceneManager.LoadScene ("menu");
		}
	}
}