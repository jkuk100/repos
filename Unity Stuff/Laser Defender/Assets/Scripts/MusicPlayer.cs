using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Update () {
		gameObject.GetComponent <AudioSource> ().volume = Settings.musicVolume;
	}
	
	void Start () {
		gameObject.GetComponent <AudioSource> ().volume = Settings.musicVolume;
		Debug.Log ("Actual Music Volume = " + gameObject.GetComponent <AudioSource> ().volume);
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
	}
}
