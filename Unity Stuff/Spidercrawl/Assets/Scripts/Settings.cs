using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
	public InputField name1;
	public InputField name2;
	public InputField name3;
	public InputField name4;

	public Text player1name;
	public Text player2name;
	public Text player3name;
	public Text player4name;



	public void Player1Name () {
		player1name.text = name1.GetComponent<InputField> ().text;
	}

	public void Player2Name () {
		player2name.text = name2.GetComponent<InputField> ().text;
	}

	public void Player3Name () {
		player3name.text = name3.GetComponent<InputField> ().text;
	}

	public void Player4Name () {
		player4name.text = name4.GetComponent<InputField> ().text;
	}


}
