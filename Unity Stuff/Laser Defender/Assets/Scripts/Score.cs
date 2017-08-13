using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score = 0;
	static Text scoreText;

	void Start () {
		scoreText = this.GetComponent<Text> ();
		scoreText.text = score.ToString();
	}

	public void ScoreCount () {
		scoreText.text = score.ToString();
	}

	public void ResetScore () {
		score = 0;
	}
}
