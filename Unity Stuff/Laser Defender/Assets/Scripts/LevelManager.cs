using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject smallShip;
	GameObject smallShipClone;
	static Scene currentScene;

	void Start () {
		smallShip.GetComponent<SpriteRenderer> ().sprite = ShipContoller.playerShipSprite;
		currentScene = SceneManager.GetActiveScene ();
		ShipTravel ();
	}

	void ShipTravel () {
		if (currentScene.name == "Start Menu" || currentScene.name == "Settings" || currentScene.name == "Win Screen") { 
			Vector3 smallShipPosition = new Vector3 (Random.Range (10f, 780f), smallShip.transform.position.y, smallShip.transform.position.z);
			smallShipClone = Instantiate (smallShip, smallShipPosition, Quaternion.identity) as GameObject;
			Destroy (smallShipClone, 25f);
			StartCoroutine (WaitToLoad (30f));
			return;
		}
	}

	IEnumerator WaitToLoad (float waitTime) {
		yield return new WaitForSecondsRealtime (waitTime);
	}

	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Application.Quit ();
	}
}
