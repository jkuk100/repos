using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static int musicInstance = 0;
	private static AudioSource music;


	// Plays the music
	public void Start () {
	
		Preferences.sfxBool = true;

		AudioSource music = GetComponent<AudioSource> ();
		music.Play ();

		//Makes sure music stays thoughout the various scenes
		GameObject.DontDestroyOnLoad (gameObject);
		musicInstance = musicInstance + 1;

		//Destroys additional scene instances if one happens to start
		if (musicInstance > 1) {
			GameObject.Destroy (gameObject);
		}
	}

	//Pauses music if music toggle is false
	public void PauseMusic () {
		AudioSource music = GetComponent<AudioSource> ();
		music.Pause ();
	}

	//Unpauses music is music toggle is true
	public void UnpauseMusic () {
		AudioSource music = GetComponent<AudioSource> ();
		music.UnPause ();
	}
}
