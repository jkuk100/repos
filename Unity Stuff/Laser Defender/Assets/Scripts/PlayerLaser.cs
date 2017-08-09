using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour {

	public Sprite playerLaser1;
	public Sprite playerLaser2;
	public Sprite playerLaser3;

	public static int playerLaserInt;


	// Use this for initialization
	void Start () {
		playerLaserInt = Settings.enemyLaser;

		if (playerLaserInt == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = playerLaser1;
		} else if (playerLaserInt == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = playerLaser2;
		} else if (playerLaserInt == 3) {
			this.GetComponent<SpriteRenderer> ().sprite = playerLaser3;
		}
	}
}
