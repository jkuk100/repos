using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIElements : MonoBehaviour {

	//Controls all UI elements of this game

	Preferences preferences;

	public Button normalLevels;
	public Button impossibleLevel;
	public Button randomLevel;
	public Text warning;
	public Toggle sfxOn;
	public Toggle musicOn;
	public Toggle smokeOn;
	public Toggle hardModeOn;
	public Toggle funModeOn;

	public static bool sfxToggleBool = true;
	public static bool musicToggleBool;
	public static bool smokeToggleBool;
	public static bool hardModeToggleBool;
	public static bool funModeToggleBool;


	public void Start () {
		LevelButtons ();
		preferences = GameObject.FindObjectOfType<Preferences> ();

		//Sets the state of the toggle switches based off of Preferences' bool states
		musicOn.isOn = Preferences.musicBool;
		sfxOn.isOn = Preferences.sfxBool;
		smokeOn.isOn = Preferences.smokeBool;
		hardModeOn.isOn = Preferences.hardModeBool;
		funModeOn.isOn = Preferences.funModeBool;
	}

	//Sets music toggle bool for Preferences to access
	public void CheckMusic () {
		if (musicOn.isOn == false) {
			musicToggleBool = false;
		} else {
			musicToggleBool = true;
		}	
		preferences.CheckMusic ();
	}

	//Sets sfx toggle bool for Preferences to access
	public void CheckSFX () {
		if (sfxOn.isOn == true) {
			sfxToggleBool = true;
		} else if (sfxOn.isOn == false) {
			sfxToggleBool = false;
		}
		preferences.CheckSFX ();
	}

	//Checks to see if smoke toogle is true or not
	public void CheckSmoke () {
		if (smokeOn.isOn == true) {
			smokeToggleBool = true;
		} else if (smokeOn.isOn == false) {
			smokeToggleBool = false;
		}
		preferences.CheckSmoke ();
	}

	//Sets hard mode toggle bool for Preferences to access
	public void CheckHardMode () {
		if (hardModeOn.isOn) {
			hardModeToggleBool = true;
			WarningText ();
		} else {
			hardModeToggleBool = false;
			WarningText ();
		}
		preferences.CheckHardMode ();
	}

	//Sets fun mode toggle bool for Preferences to access
	public void CheckFunMode () {
		if (funModeOn.isOn) {
			funModeToggleBool = true;
			WarningText ();
		} else {
			funModeToggleBool = false;
			WarningText ();
		}
		preferences.CheckFunMode ();
	}

	//Displays a warning text if both hard mode and fun mode are true
	void WarningText () {
		if (hardModeToggleBool == true && funModeToggleBool == true) {
			warning.text = "Please only choose one mode";
		} else {
			warning.text = " ";
		}	
	}

	//Sets text in Settings screen for other level buttons once the first game is played
	void LevelButtons () {
		Debug.Log ("Start buttons method running");
		if (LevelManager.gamesPlayed >= 1) {
			impossibleLevel.GetComponentInChildren<Text> ().text = "Play Impossible Level?";
			normalLevels.GetComponentInChildren<Text> ().text = "Play Normal Levels?";
			randomLevel.GetComponentInChildren<Text> ().text = "Play Random Levels?";

			Debug.Log ("Level Buttons method if statement running");
		}
	}
}
