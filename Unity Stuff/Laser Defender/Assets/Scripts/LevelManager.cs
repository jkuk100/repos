using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject smallShip;
	public Sprite shipDefaultSprite;
	public AnimationClip flyBy;

	GameObject smallShipClone;
	static Scene currentScene;

	void Start () {
		StartCoroutine (WaitToLoad (5f));
	}

	void ShipTravel () {
		Debug.Log ("ShipTravel is running");
		if (currentScene.name == "Start Menu" || currentScene.name == "Settings" || currentScene.name == "Win Screen") { 
			Debug.Log ("If statement is running");
			smallShipClone = Instantiate (smallShip, smallShip.transform.position, Quaternion.identity) as GameObject;
			Destroy (smallShipClone, 30f);
			StartCoroutine (WaitToLoad (40f));
		}
	}

	IEnumerator WaitToLoad (float waitTime) {
		yield return new WaitForSecondsRealtime (waitTime);
		Debug.Log ("Time Enumerator is running");
		currentScene = SceneManager.GetActiveScene ();
		if (Settings.playerShip != 1) {
			smallShip.GetComponent<SpriteRenderer> ().sprite = ShipContoller.playerShipSprite;	
		}

		ShipTravel();
	}

	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Application.Quit ();
	}
}
