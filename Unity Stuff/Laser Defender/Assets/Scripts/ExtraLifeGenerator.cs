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
		time = Random.Range (15f, 25f);
	}

	void LifeDrop () {
		Vector3 position = new Vector3 (Random.Range (-5f, 6.5f), 5.5f, 1);
		GameObject newLife = Instantiate (extraLifeObject, position, Quaternion.identity) as GameObject;
		newLife.GetComponent<SpriteRenderer> ().sprite = ShipContoller.playerShipSprite;
		newLife.GetComponent<BoxCollider2D> ().isTrigger = true;
		newLife.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		newLife.GetComponent<Rigidbody2D> ().mass = 1;
		newLife.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -2f);
		lifeDropped = true;
	}

	void Update () {
		if (lifeDropped == false && ShipContoller.health < 300) {
			if (time > 0f) {
				time -= Time.deltaTime;
			} else if (time <= 0) {
				LifeDrop ();
				ResetTime ();
			}
		}
	}
}