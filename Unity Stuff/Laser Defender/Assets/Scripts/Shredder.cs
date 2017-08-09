using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	//Destroys lasers when they leave play space
	void OnTriggerEnter2D (Collider2D collider) {
		Destroy (collider.gameObject);
	}
}
