using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	//Controls all variables that rely on the Ball

	public AudioSource initialLaunch;
	public bool hasStarted = false;

	private Paddle paddle;
	private Vector3 paddleToBallVector;


	void Start () {

		paddle = GameObject.FindObjectOfType<Paddle> ();	
		paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	void Update () {

		if (!hasStarted) {
			//Locks Ball relative to Paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//Waits for input (mouse click) to launch the ball
			if (Input.GetMouseButtonDown (0)) {
				//Sets the variable that stores if the game has started or not
				hasStarted = true;
				//Initial velocity for the ball
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.2f, 12f);
				//Plays "Initial Launch" sfx and returns null if the sfx toggle is false
				if (Preferences.sfxBool == true) {
					initialLaunch = GetComponent<AudioSource> ();
					initialLaunch.Play ();
				} else if (Preferences.sfxBool == false) {
					return;
				}
			}
		}
	}

	//Controls varios Collision aspects of the ball based off of the toggle states
	void OnCollisionEnter2D (Collision2D collison) {
		Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D> ();

		//Additional velocity factors for the ball to keep it from getting in a boring loop and to add if a toggle is true
		Vector2 normalTweak = new Vector2 (Random.Range (0f, 0.5f), Random.Range (0f, 0.5f));
		Vector2 hardTweak = new Vector2 (Random.Range (0.5f, 3f), Random.Range (0.5f, 3f));
		Vector2 funTweak = new Vector2 (Random.Range (2f, 4f), Random.Range (2f, 4f));

		//Changes gravity scale and adds velocity tweak based off of toggle states
		if (Preferences.hardModeBool == true) {
			rigidbody2D.gravityScale = Random.Range (0.1f, 3f);
			rigidbody2D.velocity += hardTweak;
		} else if (Preferences.funModeBool == true) {
			rigidbody2D.gravityScale = Random.Range (-1f, 3f);
			rigidbody2D.velocity += funTweak;
		} else {
			rigidbody2D.gravityScale = 1;
			rigidbody2D.velocity += normalTweak;
		}
	}
}