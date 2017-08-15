using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeGenerator : MonoBehaviour {

	public GameObject extraLifeObject;

	public static bool lifeDropped;

	static float time;


	void Start () {
		extraLifeObject.GetComponent<SpriteRenderer> ().sprite = ShipContoller.playerShipSprite;
		lifeDropped = false;
		ResetTime ();
	}

	void ResetTime () {
		time = Random.Range (5f, 10f);
	}

	void LifeDrop () {
		Vector3 position = new Vector3 (Random.Range (-5f, 6.5f), 5.5f, 1);
		GameObject lifeDrop = Instantiate (extraLifeObject, position, Quaternion.identity) as GameObject;
		lifeDrop.GetComponent<SpriteRenderer> ().sprite = ShipContoller.playerShipSprite;
		lifeDrop.GetComponent<BoxCollider2D> ().isTrigger = true;
		lifeDrop.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		lifeDrop.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -2f);
		lifeDropped = true;
	}

	void Update () {
		if (lifeDropped == false && ShipContoller.health < 300) {
			if (time > 0f) {
				time -= Time.deltaTime;
				Debug.Log ("Before Time: " + time);
			} else if (time <= 0) {
				LifeDrop ();
				ResetTime ();
				Debug.Log (time);
			}
		}
	}
}