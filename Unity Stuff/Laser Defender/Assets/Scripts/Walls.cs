using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	void Start () {
		if (!Settings.bounceMode) {
			Destroy (gameObject);	
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (this.transform.position.x > 0) {
			collider.GetComponent<Transform> ().Rotate (0, 0, 90);
			collider.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range (-9, -5), Random.Range (3, 6));

		} else if (this.transform.position.x <= 0) {
			collider.GetComponent<Transform> ().Rotate (0, 0, 270);
			collider.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range (5, 9), Random.Range (3, 6));
		}
	}
}
