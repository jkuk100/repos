using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public static int score = 0;

	void Start () {
		scoreText.text = score.ToString();
	}

	public void ScoreCount () {
		scoreText.text = score.ToString();
	}

	public void ResetScore () {
		score = 0;
	}
}
