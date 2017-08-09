using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//Controls the different LevelManager aspects

	Preferences preferences;

	public static int brickAmount;
	public static int gamesPlayed;

	void Start () {
		preferences = GameObject.FindObjectOfType<Preferences> ();
	}

	//Loads specified scene (using a string input), runs Restart method from this script
	public void LoadLevel (string name) {
		SceneManager.LoadScene (name);
		preferences.CheckSFX ();
		Restart ();
	}

	//Loads next level in build settings (based off of numerical order in the build settings menu)
	public void LoadNextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	//Quits the game
	public void QuitLevel () {
		Application.Quit ();
	}

	//Loads the next level if the breakable count reaches 0
	public void BrickDestroyed () {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

	//Initializes brick number to 0 if a level is loaded using LoadLevel
	void Restart () {
		Brick.breakableCount = 0;
	}

	//Records amount of games played when someone presses a button with this method attached to it
	public void GamesPlayed () {
		gamesPlayed++;
	}
}
