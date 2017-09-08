using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritePicker : MonoBehaviour {

	public ToggleGroup enemyShipToggleGroup;
	public ToggleGroup playerShipToggleGroup;
	public ToggleGroup enemyLaserToggleGroup;
	public ToggleGroup playerLaserToggleGroup;

	#region Enemy and Player Sprite Picker Toggles
	//Enemy Ship and Laser Toggles
	public Toggle enemyShip1;
	public Toggle enemyShip2;
	public Toggle enemyShip3;
	public Toggle enemyShip4;
	public Toggle enemyShip5;
	public Toggle enemyShip6;
	public Toggle enemyLaser1;
	public Toggle enemyLaser2;
	public Toggle enemyLaser3;

	//Player Ship and Laser Toggles
	public Toggle playerShip1;
	public Toggle playerShip2;
	public Toggle playerShip3;
	public Toggle playerShip4;
	public Toggle playerShip5;
	public Toggle playerShip6;
	public Toggle playerLaser1;
	public Toggle playerLaser2;
	public Toggle playerLaser3;

	#endregion

	//Enemy Ship and Laser Toggles
	public static int enemyShip = 1;
	public static int enemyLaser = 1;
	public static int playerShip = 1;
	public static int playerLaser = 1;
	public static bool playerLaserisCool = true;



	// Use this for initialization
	void Start () {
		playerLaser = PlayerLaser.playerLaserInt;
		playerShip = ShipContoller.playerShipInt;
		enemyLaser = EnemyLaser.enemyLaserInt;
		enemyShip = EnemyShip.enemyShipInt;

		#region Initial Sprite Toggle Enabler
		if (playerLaser == 1) {
			playerLaser1.isOn = true;
		} else if (playerLaser == 2) {
			playerLaser2.isOn = true;
		} else if (playerLaser == 3) {
			playerLaser3.isOn = true;
		}

		if (playerShip == 1) {
			playerShip1.isOn = true;
		} else if (playerShip == 2) {
			playerShip2.isOn = true;
		} else if (playerShip == 3) {
			playerShip3.isOn = true;
		} else if (playerShip == 4) {
			playerShip4.isOn = true;
		} else if (playerShip == 5) {
			playerShip5.isOn = true;
		} else if (playerShip == 6) {
			playerShip6.isOn = true;
		}

		if (enemyLaser == 1) {
			enemyLaser1.isOn = true;
		} else if (enemyLaser == 2) {
			enemyLaser2.isOn = true;
		} else if (enemyLaser == 3) {
			enemyLaser3.isOn = true;
		}

		if (enemyShip == 1) {
			enemyShip1.isOn = true;
		} else if (enemyShip == 2) {
			enemyShip2.isOn = true;
		} else if (enemyShip == 3) {
			enemyShip3.isOn = true;
		} else if (enemyShip == 4) {
			enemyShip4.isOn = true;
		} else if (enemyShip == 5) {
			enemyShip5.isOn = true;
		} else if (enemyShip == 6) {
			enemyShip6.isOn = true;
		} 
	}

	#endregion
	
	#region Sprite Check Functions
	public void EnemyShipCheck () {
		if (enemyShip1.isOn) {
			enemyShip = 1;
		} else if (enemyShip2.isOn) {
			enemyShip = 2;
		} else if (enemyShip3.isOn) {
			enemyShip = 3;
		} else if (enemyShip4.isOn) {
			enemyShip = 4;
		} else if (enemyShip5.isOn) {
			enemyShip = 5;
		} else if (enemyShip6.isOn) {
			enemyShip = 6;
		}
	}

	public void EnemyLaserCheck () {
		if (enemyLaser1.isOn) {
			enemyLaser = 1;
		} else if (enemyLaser2.isOn) {
			enemyLaser = 2;
		} else if (enemyLaser3.isOn) {
			enemyLaser = 3;
		}
	}

	public void PlayerLaserCheck () {
		if (playerLaser1.isOn) {
			playerLaser = 1;
		} else if (playerLaser2.isOn) {
			playerLaser = 2;
		} else if (playerLaser3.isOn) {
			playerLaser = 3;
		}
	}

	public void PlayerShipCheck () {
		if (playerShip1.isOn) {
			playerShip = 1;
		} else if (playerShip2.isOn) {
			playerShip = 2;
		} else if (playerShip3.isOn) {
			playerShip = 3;
		} else if (playerShip4.isOn) {
			playerShip = 4;
		} else if (playerShip5.isOn) {
			playerShip = 5;
		} else if (playerShip6.isOn) {
			playerShip = 6;
		}
	}
	#endregion
}
