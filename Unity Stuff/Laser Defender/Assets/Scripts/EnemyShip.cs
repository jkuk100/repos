using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
	
	Score scoreScript;

	public AudioClip enemyShot;
	public AudioClip enemyDie;
	public Sprite enemyShip1;
	public Sprite enemyShip2;
	public Sprite enemyShip3;
	public Sprite enemyShip4;
	public Sprite enemyShip5;
	public Sprite enemyShip6;

	public GameObject laserSprite;

	public float health = 200f;
	public bool enemyFlyInState = true;
	public bool enemyDead;

	public static int enemyShipInt;

	float laserSpeed = 10f;
	float shotsPerSecond; //Frequency of laser shots

	void Start () {
		enemyDead = false;
		enemyShipInt = Settings.enemyShip;
		if (enemyShipInt == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyShip1;	
		} else if (enemyShipInt == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyShip2;
		} else if (enemyShipInt == 3) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyShip3;
		} else if (enemyShipInt == 4) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyShip4;
		} else if (enemyShipInt == 5) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyShip5;
		} else if (enemyShipInt == 6) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyShip6;
		}
		
		shotsPerSecond = Random.Range (0.1f, 0.3f);

		//Sets the script to recieve the score script
		scoreScript = FindObjectOfType<Score> ();
	}



	//Creates instances of the enemies' laser
	void FireShot () {
		if (enemyDead == false) {
			if (enemyFlyInState == false) {

				//Plays the enemyShotSFX + changes pitch and pans for each shot
				Vector3 panning = new Vector3 ((transform.position.x / 6.1f), transform.position.y, transform.position.z);
				AudioSource.PlayClipAtPoint (enemyShot, panning, Settings.sfxVolume);

				//Creates instances of enemy lasers and sets their velocity
				GameObject laser = Instantiate (laserSprite, transform.position, Quaternion.identity) as GameObject;
				laser.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -laserSpeed);
			}
		}
	}

	//Sets randomizer to when the enemy shot will be fired
	void Update () {

		//Randomly fires enemy shots
		float probability = Time.deltaTime * shotsPerSecond;
		if (ShipContoller.playerDead == false | enemyFlyInState == false) { //Only shoots lasers if player is still alive or if animation done
			if (Random.value < probability) {
				FireShot ();
			}
		}
	}

	//Destroys the enemy ships
	void OnTriggerEnter2D (Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();

		if (projectile) {
			projectile.Hit ();
			health -= projectile.GetDamage ();
			if (health <= 0) {
				enemyDead = true;
				GetComponent<PolygonCollider2D> ().enabled = false;
				if (Settings.enemySmoke) {
					GetComponent<ParticleSystem> ().Play ();
				}
				GetComponent<SpriteRenderer> ().enabled = false;
				Vector3 panning = new Vector3 ((transform.position.x / 6.1f), transform.position.y, transform.position.z);
				AudioSource.PlayClipAtPoint (enemyDie, panning, Settings.sfxVolume);

				Score.score = Score.score + 100;
				scoreScript.ScoreCount ();
				Destroy (this.gameObject, Time.deltaTime * 50);
			}
		}
	}
}
