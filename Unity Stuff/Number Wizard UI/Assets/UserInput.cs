	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class UserInput : MonoBehaviour {

	public Toggle hard_mode;
	private static bool isHardmode = false;

	public void Start () {
		isHardmode = false;
	}
		


	//Sets Difficulty Level (changes guessing equation)
	public void ActiveToggle () {
		if (hard_mode.isOn) { 
			Debug.Log ("Hard mode is on"); 
			isHardmode = true;
			IsHardMode ();
		} else { 
			Debug.Log ("Hard mode is off");
			isHardmode = false;
			IsHardMode ();
		}
	}
		

	public static bool IsHardMode() {
		Debug.Log ("isHardmode = " + isHardmode.ToString ());
		return isHardmode;
	}

}