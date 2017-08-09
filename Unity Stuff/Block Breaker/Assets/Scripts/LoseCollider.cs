using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	//Manages Lose Collider settings
	private LevelManager levelManager;
	public string loseLevel;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
		

	//Runs LevelManager method to load a level if the ball collides with the Lose Collider, set to load the Lose scene
	public void OnCollisionEnter2D (Collision2D collision) {
		levelManager.LoadLevel (loseLevel);
	}
}
