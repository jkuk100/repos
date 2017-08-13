using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip song1;
	public AudioClip song2;
	public AudioClip song3;
	public AudioClip song4;

	AudioSource song;
	static MusicPlayer instance = null;

	void Update () {

		//Changes Song When Dropdown number is changed 
		gameObject.GetComponent <AudioSource> ().volume = Settings.musicVolume;
		if (Settings.songNumber == 1) {
			song.Pause ();
			song.clip = song1;
			song.Play ();
		} else if (Settings.songNumber == 2) {
			song.Pause ();
			song.clip = song2;
			song.Play ();
		} else if (Settings.songNumber == 3) {
			song.Pause ();
			song.clip = song3;
			song.Play ();
		} else if (Settings.songNumber == 4) {
			song.Pause ();
			song.clip = song4;
			song.Play ();
		} 
	}
	
	void Start () {
		
		song = this.GetComponent<AudioSource> ();
		gameObject.GetComponent <AudioSource> ().volume = Settings.musicVolume;

		//Creates a gameobject for the MusicPlayer and destroys any additional ones
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
	}
}
