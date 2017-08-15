using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife: MonoBehaviour {

	public GameObject lifeObject;
	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	public AudioClip powerUpSFX;

	//Triggers health increase if health is < 300 when the life is shot
	public void OnTriggerEnter2D (Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile> ();
		projectile.Hit ();

		if (ShipContoller.health == 100) {
			life2.GetComponent<SpriteRenderer> ().enabled = true;
		} else if (ShipContoller.health == 200) {
			life3.GetComponent<SpriteRenderer> ().enabled = true;
		} else if (ShipContoller.health == 300) {
			Destroy (gameObject);
			return;
		}

		Vector3 panning = new Vector3 ((transform.position.x / 6.1f), transform.position.y, transform.position.z);
		AudioSource.PlayClipAtPoint (powerUpSFX, panning, Settings.sfxVolume);
		ShipContoller.health = ShipContoller.health + 100;
		ExtraLifeGenerator.lifeDropped = false;
		Destroy (gameObject);
	}
}
