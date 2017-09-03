using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour {

	//UI Components
	public Slider sfxSlider;
	public Slider musicSlider;
	public Toggle hecticModeToggle;
	public Toggle bounceModeToggle;
	public Toggle enemyTrailsToggle;
	public Toggle enemySmokeToggle;
	public Dropdown songChoice;
	public ToggleGroup enemyShipToggleGroup;
	public ToggleGroup playerShipToggleGroup;
	public ToggleGroup enemyLaserToggleGroup;
	public ToggleGroup playerLaserToggleGroup;

	public GameObject enemyPrefab;

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
	public static float sfxVolume = 1f;
	public static float musicVolume = 0.75f;

	//Additional UI States
	public static bool hecticMode = false;
	public static bool bounceMode = false;
	public static bool enemyTrails = true;
	public static bool enemySmoke = true;
	public static int songNumber = 0;

	void Start () {
		songChoice.value = songNumber;
		sfxSlider.value = sfxVolume;
		musicSlider.value = musicVolume;
		bounceModeToggle.isOn = bounceMode;
		hecticModeToggle.isOn = hecticMode;
		enemyTrailsToggle.isOn = enemyTrails;
		enemySmokeToggle.isOn = enemySmoke;




		#region Toggle Group Check
		if (enemyShip == 1) { 
			//enemyShipToggleGroup.NotifyToggleOn (enemyShip1);
		} else if (enemyShip == 2) { 
			//enemyShipToggleGroup.NotifyToggleOn (enemyShip2);
		} else if (enemyShip == 3) { 
			//enemyShipToggleGroup.NotifyToggleOn (enemyShip3);
		} else if (enemyShip == 4) { 
			//enemyShipToggleGroup.NotifyToggleOn (enemyShip4);
		} else if (enemyShip == 5) { 
			//enemyShipToggleGroup.NotifyToggleOn (enemyShip5);
		} else if (enemyShip == 6) { 
			//enemyShipToggleGroup.NotifyToggleOn (enemyShip6);
		}

		if (playerShip == 1) {
			playerShipToggleGroup.NotifyToggleOn (playerShip1);
		} else if (playerShip == 2) {
			playerShipToggleGroup.NotifyToggleOn (playerShip2);
		} else if (playerShip == 3) {
			playerShipToggleGroup.NotifyToggleOn (playerShip3);
		} else if (playerShip == 4) {
			playerShipToggleGroup.NotifyToggleOn (playerShip4);
		} else if (playerShip == 5) {
			playerShipToggleGroup.NotifyToggleOn (playerShip5);
		} else if (playerShip == 6) {
			playerShipToggleGroup.NotifyToggleOn (playerShip6);
		}

		if (enemyLaser == 1) {
			enemyLaserToggleGroup.NotifyToggleOn (enemyLaser1);
		} else if (enemyLaser == 2) {
			enemyLaserToggleGroup.NotifyToggleOn (enemyLaser2);
		} else if (enemyLaser == 3) {
			enemyLaserToggleGroup.NotifyToggleOn (enemyLaser3);
		}

		if (playerLaser == 1) {
			playerLaserToggleGroup.NotifyToggleOn (playerLaser1);
		} else if (playerLaser == 2) {
			playerLaserToggleGroup.NotifyToggleOn (playerLaser2);
		} else if (playerLaser == 3) {
			playerLaserToggleGroup.NotifyToggleOn (playerLaser3);
		}
		#endregion	
	}


	public void SFXChange () {
		sfxVolume = sfxSlider.value;
	}

	public void MusicChange () {
		musicVolume = musicSlider.value;
	}

	public void SmokeState () {
		enemySmoke = enemySmokeToggle.isOn;
	}

	public void TrailsState () {
		enemyTrails = enemyTrailsToggle.isOn;
		if (enemyTrails == false) {
			enemyPrefab.GetComponent<TrailRenderer> ().enabled = false;
		} else {
			enemyPrefab.GetComponent<TrailRenderer> ().enabled = true;
		}
	}

	public void HecticModeState() {
		hecticMode = hecticModeToggle.isOn;
	}

	public void BounceModeState() {
		bounceMode = bounceModeToggle.isOn;
	}

	public void SongCheck () {
		songNumber = songChoice.value;
	}

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
