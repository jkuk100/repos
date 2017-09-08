using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipContoller : MonoBehaviour {

	public AudioClip playerDie;
	public AudioClip playerLaser;
	public AudioClip playerHit;
	public Text ammoCountText;
	Animator animator;

	public GameObject laserSprite;
	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	public GameObject extraLife;

	public Sprite playerShip1;
	public Sprite playerShip2;
	public Sprite playerShip3;
	public Sprite playerShip4;
	public Sprite playerShip5;
	public Sprite playerShip6;
	public static Sprite playerShipSprite;

	public static float newX;
	public static bool playerDead;
	public static int playerShipInt;
	public static int livesCounterOnShip;
	public static float health = 300f;
	public static int ammo;

	float speed = 7f;
	float padding = 0.5f;
	float xMin;
	float xMax;


	void Start () {
		animator = GetComponentInChildren<Animator>();

		#region Sprite Changer
		playerShipInt = SpritePicker.playerShip;
		if (playerShipInt == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip1;
			life1.GetComponent<SpriteRenderer> ().sprite = playerShip1;
			life2.GetComponent<SpriteRenderer> ().sprite = playerShip1;
			life3.GetComponent<SpriteRenderer> ().sprite = playerShip1;
			extraLife.GetComponent<SpriteRenderer> ().sprite = playerShip1;
			playerShipSprite = playerShip1;
		} else if (playerShipInt == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip2;
			life1.GetComponent<SpriteRenderer> ().sprite = playerShip2;
			life2.GetComponent<SpriteRenderer> ().sprite = playerShip2;
			life3.GetComponent<SpriteRenderer> ().sprite = playerShip2;
			extraLife.GetComponent<SpriteRenderer> ().sprite = playerShip2;
			playerShipSprite = playerShip2;
		} else if (playerShipInt == 3) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip3;
			life1.GetComponent<SpriteRenderer> ().sprite = playerShip3;
			life2.GetComponent<SpriteRenderer> ().sprite = playerShip3;
			life3.GetComponent<SpriteRenderer> ().sprite = playerShip3;
			extraLife.GetComponent<SpriteRenderer> ().sprite = playerShip3;
			playerShipSprite = playerShip3;
		} else if (playerShipInt == 4) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip4;
			life1.GetComponent<SpriteRenderer> ().sprite = playerShip4;
			life2.GetComponent<SpriteRenderer> ().sprite = playerShip4;
			life3.GetComponent<SpriteRenderer> ().sprite = playerShip4;
			extraLife.GetComponent<SpriteRenderer> ().sprite = playerShip4;
			playerShipSprite = playerShip4;
		} else if (playerShipInt == 5) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip5;
			life1.GetComponent<SpriteRenderer> ().sprite = playerShip5;
			life2.GetComponent<SpriteRenderer> ().sprite = playerShip5;
			life3.GetComponent<SpriteRenderer> ().sprite = playerShip5;
			extraLife.GetComponent<SpriteRenderer> ().sprite = playerShip5;
			playerShipSprite = playerShip5;
		} else if (playerShipInt == 6) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip6;
			life1.GetComponent<SpriteRenderer> ().sprite = playerShip6;
			life2.GetComponent<SpriteRenderer> ().sprite = playerShip6;
			life3.GetComponent<SpriteRenderer> ().sprite = playerShip6;
			extraLife.GetComponent<SpriteRenderer> ().sprite = playerShip6;
			playerShipSprite = playerShip6;
		}
		#endregion

		playerDead = false; // States that player is alive

		ammo = 15;
		if (Settings.hecticMode) {
			ammoCountText.text = "Ammo: " + ammo;
		} else {
			ammoCountText.text = " ";
		}

		//creates screen borders
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
	
	}

	//Creates instances of the player's laser
	void FireShot () {
		if (Settings.hecticMode && ammo > 0) {
			ammo = ammo - 1;
			ammoCountText.text = "Ammo: " + ammo;
		} 

		//Plays the SFX + changes pitch and pans for each shot
		Vector3 panning = new Vector3 ((transform.position.x / 6.1f), transform.position.y, transform.position.z);
		AudioSource.PlayClipAtPoint (playerLaser, panning, Settings.sfxVolume);

		//Creates each instance of a laser and sets its velocity
		GameObject laser = Instantiate (laserSprite, transform.position, Quaternion.identity) as GameObject;
		if (Settings.bounceMode) {
			if (this.gameObject.transform.position.x < 0) {
				laser.GetComponent<Transform> ().Rotate (0, 0, 45);
				laser.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-7, 3);
			} else {
				laser.GetComponent<Transform> ().Rotate (0, 0, 315);
				laser.GetComponent<Rigidbody2D> ().velocity = new Vector2 (7, 3);
			}
		} else {
			laser.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 10);
		}
	}

	public void AmmoCount () {
		ammo = ammo + 3;
		ammoCountText.text = "Ammo: " + ammo;
	}

	//Decreases health if ship is hit
	void OnTriggerEnter2D (Collider2D collider) {
		//Scripts for this method
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();

		//Controls the health for the Main Ship and what happens when it gets hit
		if (projectile) {
			projectile.Hit ();
			Vector3 panning = new Vector3 ((transform.position.x / 6.1f), transform.position.y, transform.position.z);
			health -= projectile.GetDamage ();
			if (health == 200) {
				life3.GetComponent<SpriteRenderer> ().enabled = false;
				animator.Play ("PlayerLoseLife", -1, 0f);
				animator.ResetTrigger ("PlayerLoseLife");
				AudioSource.PlayClipAtPoint (playerHit, panning, Settings.sfxVolume);
			} else if (health == 100) {
				life2.GetComponent<SpriteRenderer> ().enabled = false;
				animator.Play ("PlayerLoseLife", -1, 0f);
				AudioSource.PlayClipAtPoint (playerHit, panning, Settings.sfxVolume);
			} else if (health <= 0) {
				playerDead = true;
				PlayerLost ();
			}
		}
	}

	void PlayerLost () {
		life1.GetComponent<SpriteRenderer> ().enabled = false;
		animator.Play ("PlayerLost", -1, 0f);
		Vector3 panning = new Vector3 ((transform.position.x / 6.1f), transform.position.y, transform.position.z);
		AudioSource.PlayClipAtPoint (playerDie, panning, Settings.sfxVolume);

		StartCoroutine (WaitToDestroy (0.5f)); //Starts countdown to destroy object and continue level load
	}

	//Destroys the GameObject and loads level after set time (Ideally once SFX is done)
	IEnumerator WaitToDestroy (float waitTime) {
		yield return new WaitForSecondsRealtime (waitTime);
		Destroy (this.gameObject);
		LevelManager continueOn = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		continueOn.LoadLevel ("Win Screen");
		health = 300;
	}

	void Update () {
		//Invokes/Calls/CancelsInvoke of FireShot method depending on space bar state and enemy state
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (ammo > 0) {
					if (playerDead == false) {
						if (EnemyShip.enemyFlyInState == false) { 
							InvokeRepeating ("FireShot", 0.00001f, 0.3f);
						}
					}
				}
			}

		//Cancels Shots when someone holds down the space bar if enemys are flying in
		if (EnemyShip.enemyFlyInState == true) {
			CancelInvoke ("FireShot");
		}

		//Cancels Shots if someone lets up on the space bar
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("FireShot");
		} 

		//Starts Lose Game sequence if someone runs out of ammo
		if (ammo <= 0 && playerDead == false) {
			playerDead = true;
			StartCoroutine (PlayerLosing (0.7f));
		}

		//moves spaceship to left and right
		if (Input.GetKey (KeyCode.RightArrow) == true) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.LeftArrow) == true) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		}

		//restricts gamespace
		newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}

	IEnumerator PlayerLosing (float waitTime) {
		yield return new WaitForSecondsRealtime (waitTime);
		PlayerLost ();
		//Fix issue where player loses even if they destroy enemy with their last shot
	}
}
