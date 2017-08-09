using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLoseCollider : MonoBehaviour {

	//Manages Special Lose Collider settings

	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	//Runs LevelManager method to load a level if the ball collides with the Lose Collider, set to load the Lose scene
	public void OnCollisionEnter2D (Collision2D collision) {
		levelManager.LoadLevel ("Special Lose");
	}
}
