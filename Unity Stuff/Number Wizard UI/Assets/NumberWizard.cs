using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

	public InputField set_min;
	public InputField set_max;
	public InputField set_guess_number;

	public Text guess_text;
	public Text GuessNumber;
	public Text pleaseMessage;

	bool check1;
	bool check2;
	bool check3;

	static int min;
	static int max;
	static int guess;
 	static int guessNumber;
	int guessPrevious;

	void Awake () {
		NextGuess ();
	}

	//Checks the input fields and converts/records their values
	public void OnSubmit ()	{
		
		check1 = int.TryParse (set_min.text, out min);
		if (check1 == true) {
			min = Int32.Parse (set_min.text);
			Debug.Log ("Min is: " + min + check1);
		}

		check2 = int.TryParse (set_max.text, out max);
		if (check2 == true) {
			max = Int32.Parse (set_max.text);
			Debug.Log ("Max is: " + max + check2);
		}

		check3 = int.TryParse (set_guess_number.text, out guessNumber);
		if (check3 == true) {
			check3 = true;
			guessNumber = Int32.Parse (set_guess_number.text);
			Debug.Log ("Guess Number is: " + guessNumber + check3);
		}

		if (min >= max) { pleaseMessage.text = "Please make sure the minimum value is less than the maximum."; }
		else { pleaseMessage.text = " "; }
	}

	//Guesses higher
	public void GuessHigher () {
		Debug.Log ("GuessHigher just ran");
		min = guess;
		guessNumber = guessNumber - 1;
		NextGuess ();
	}

	//Guesses Lower
	public void GuessLower () {
		Debug.Log ("GuessLower just ran");
		max = guess;
		guessNumber = guessNumber - 1;
		NextGuess ();
	}

	//Creates new guesses and monitors the number of guesses
	public void NextGuess () {
		Debug.Log ("NextGuess is running");
		Debug.Log ("Guess Min=" + min + "Max=" + max + "Guess Number=" + guessNumber);
	
		if (UserInput.IsHardMode()) {
			guess = (max + min) / 2;
			Debug.Log ("guess = (max + min) / 2");
		} else {
			guess = UnityEngine.Random.Range (min, max);
			Debug.Log ("UnityEngine.Random.Range (min, max);");
		}			

		guess_text.text = ("Is it " + guess.ToString () + "?");
		Debug.Log ("Guess: " + guess);

		GuessNumber.text = "Guesses Left: \n" + guessNumber.ToString(); 
		if (guessNumber <= 0) { SceneManager.LoadScene ("Win"); }
	}
}