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

	public GameObject enemyPrefab;

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
}
