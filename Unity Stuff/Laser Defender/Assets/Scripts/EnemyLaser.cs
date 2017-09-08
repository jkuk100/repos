using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour {

	public Sprite enemyLaser1;
	public Sprite enemyLaser2;
	public Sprite enemyLaser3;

	public static int enemyLaserInt;


	// Use this for initialization
	void Start () {
		enemyLaserInt = SpritePicker.enemyLaser;

		if (enemyLaserInt == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyLaser1;
		} else if (enemyLaserInt == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyLaser2;
		} else if (enemyLaserInt == 3) {
			this.GetComponent<SpriteRenderer> ().sprite = enemyLaser3;
		}
	}
}
