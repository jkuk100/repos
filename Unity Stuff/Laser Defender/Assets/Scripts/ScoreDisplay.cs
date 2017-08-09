using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {


	void Start () {
		Text scoreDisplay = GetComponent<Text> ();
		scoreDisplay.text = Score.score.ToString ();
		Score.score = 0;
	}
}
