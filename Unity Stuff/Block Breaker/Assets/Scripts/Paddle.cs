using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	//Controls various aspects of the paddle

	public bool autoPlay = false;
	public Ball ball;
	public float mousePosInBlocks;
	public AudioSource bounce;

	void Start () { 
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	// Plays SFX when ball collides with paddle
	void OnCollisionEnter2D (Collision2D collision) {
		if (ball.hasStarted == true) {
			if (Preferences.sfxBool == true) {
				bounce = GetComponent<AudioSource> ();
				bounce.Play ();
			}
		}
	}
	
	// Checks if AutoPlay is enabled or controlled by mouse
	void Update () {

		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	//Paddle controlled to follow X position of ball
	void AutoPlay () {
		Vector3 paddlePos = new Vector3 (0f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = (Mathf.Clamp (ballPos.x, 0.75f, 15.3f));
		this.transform.position = paddlePos;
	}
		
	//Paddle controlled by mouse position
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0f, this.transform.position.y, 0f);
		mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		paddlePos.x = (Mathf.Clamp (mousePosInBlocks, 0.75f, 15.3f));
		this.transform.position = paddlePos;
	}
}
