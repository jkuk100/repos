using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	void Start () {
		Vector3 leftWall = new Vector3 (-7.15f, 0f, 1f);
		Vector3 rightWall = new Vector3 (7.15f, 0f, 1f);
		if (Settings.bounceMode == true) {
			GameObject sideWall1 = Instantiate (this.gameObject, leftWall, Quaternion.identity) as GameObject;
			GameObject sideWall2 = Instantiate (this.gameObject, rightWall, Quaternion.identity) as GameObject;
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
			
	
	}
	

	void Update () {
		
	}
}
