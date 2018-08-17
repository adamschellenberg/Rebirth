using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;

	public int score;

	public GameObject prefab;
	public float gridX = 5f;
	public float gridY = 5f;
	public float spacing = 2f;
	public float xPos;
	public float yPos;

	public float respawnCoolDown = 5;
	public int difficulty = 0;

	// Use this for initialization
	void Start () {

		score = 0;
		UpdateScore ();
		respawnCoolDown = 5;
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScore ();
		if (respawnCoolDown > 0) {
		
			respawnCoolDown -= Time.deltaTime;
		
		} else {
			SpawnEnemies ();
			difficulty++;

			if (difficulty < 5) {
				respawnCoolDown = 5;
			} else if (difficulty > 5 && difficulty < 10) {
				respawnCoolDown = 3;
			} else {
				respawnCoolDown = 1;
			}
		}
	}

	void UpdateScore () {
	
		scoreText.text = "Score: " + score.ToString();
	
	}

	void SpawnEnemies() {

		xPos = Random.Range (0f, 77f);
		yPos = Random.Range (0f, 57f);
		Vector3 pos = new Vector3(xPos, yPos, 0);
		Instantiate(prefab, pos, Quaternion.identity);

	}
}
