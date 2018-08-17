using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

	public Collider2D weaponCollider;
	SpriteRenderer weaponSprite;

	private bool attacking;
	private float coolDownTimer;
	public float coolDownTimerReset = 0.3f;

	public GameController scoreCount;

	// Use this for initialization
	void Start () {
		weaponCollider = GetComponent<Collider2D>();
		weaponSprite = GetComponent<SpriteRenderer> ();
		weaponCollider.enabled = false;
		coolDownTimer = coolDownTimerReset;
		weaponSprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && attacking == false) {
			weaponCollider.enabled = true;
			weaponSprite.enabled = true;
			attacking = true;
		}

		if (attacking == true) {
			if (coolDownTimer > 0) {
				coolDownTimer -= Time.deltaTime;
			} else {
				coolDownTimer = coolDownTimerReset;
				attacking = false;
				weaponCollider.enabled = false;
				weaponSprite.enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			Destroy(other.gameObject);
			print ("You defeated the enemy!");
			scoreCount.score = scoreCount.score + 1;
		}
	}
}