using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife: MonoBehaviour {

	public GameObject lifeObject;
	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	public AudioClip powerUpSFX;

	public static int amountOfLivesObjects;


	static float time;

	void Start () {
		GetComponent<SpriteRenderer> ().sprite = ShipContoller.playerShipSprite;
		amountOfLivesObjects = 0;
		ResetTime ();
	}

	void ResetTime () {
		time = Random.Range (12f, 20f);
	}

	public void OnCollisionEnter2D (Collision2D collision) {
		Projectile projectile = collision.gameObject.GetComponent<Projectile> ();
		projectile.Hit ();
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();
		projectile.Hit ();
		if (ShipContoller.health == 100) {
			life2.GetComponent<SpriteRenderer> ().enabled = true;
		} else if (ShipContoller.health == 200) {
			life3.GetComponent<SpriteRenderer> ().enabled = true;
		}
		Vector3 panning = new Vector3 ((transform.position.x / 6.1f), transform.position.y, transform.position.z);
		AudioSource.PlayClipAtPoint (powerUpSFX, panning, Settings.sfxVolume);
		ShipContoller.health = ShipContoller.health + 100;
		Destroy (gameObject);
		amountOfLivesObjects = 0;
	}

	public void LifeDrop () {
		Vector3 position = new Vector3 (Random.Range (-5f, 6.5f), 6.23f, 1);
		if (amountOfLivesObjects <= 0 && ShipContoller.health < 300) {
			amountOfLivesObjects = amountOfLivesObjects + 1;
			GameObject lifeDrop = Instantiate (lifeObject, position, Quaternion.identity) as GameObject;
			lifeDrop.GetComponent<PolygonCollider2D> ().isTrigger = true;
			lifeDrop.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
			lifeDrop.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -2f);
		}
	}

	void Update () {
		if (amountOfLivesObjects <= 0 && ShipContoller.health < 300) {
			if (time > 0f) {
				time -= Time.deltaTime;
			} else { 
				ResetTime ();
				LifeDrop ();
			}
		}
	}
}
