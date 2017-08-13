using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static string currentSceneName;

	void Start () {
		currentSceneName = SceneManager.GetActiveScene ().name;
	}

	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Application.Quit ();
	}
}
