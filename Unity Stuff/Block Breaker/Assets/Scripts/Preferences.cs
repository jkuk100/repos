using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Preferences : MonoBehaviour {

	//Stores all UIElement bool states in static variables and allows other scripts to access them

	public static bool sfxBool;
	public static bool musicBool = true;
	public static bool smokeBool = true;
	public static bool hardModeBool;
	public static bool funModeBool;

	MusicPlayer musicPlayer;

	void Start () {

		musicPlayer = GameObject.FindObjectOfType<MusicPlayer> ();
	}

	//Checks if Music bool from UIElements script is true/false, and  runs methods from MusicPlayer script based off of toggle state
	public void CheckMusic () {
		if (UIElements.musicToggleBool == false) {
			musicPlayer.PauseMusic ();
			musicBool = false;
		} else {
			musicPlayer.UnpauseMusic ();
			musicBool = true;
		}	
	}

	//Checks UIElements sfx bool and store it in a static variable for other scripts to see
	public void CheckSFX () {
		if (UIElements.sfxToggleBool == true) {
			sfxBool = true;
		} else if (UIElements.sfxToggleBool == false) {
			sfxBool = false;
		}
	}

	public void CheckSmoke () {
		if (UIElements.smokeToggleBool == true) {
			smokeBool = true;
		} else if (UIElements.smokeToggleBool == false) {
			smokeBool = false;
		}
	}

	//Checks UIElements hard mode bool and store it in a static variable for other scripts to see
	public void CheckHardMode () {
		if (UIElements.hardModeToggleBool) {
			hardModeBool = true;
		} else {
			hardModeBool = false;
		}
	}

	//Checks UIElements fun mode bool and store it in a static variable for other scripts to see
	public void CheckFunMode () {
		if (UIElements.funModeToggleBool == true) {
			funModeBool = true;
		} else {
			funModeBool = false;
		}
	}
}