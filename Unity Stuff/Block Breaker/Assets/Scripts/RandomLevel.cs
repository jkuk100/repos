using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour {

	//Generates a randomized level

	public GameObject brick1Hit;
	public GameObject brick2Hit;
	public GameObject brick3Hit;

	int brick1Counter = 0;
	int brick2Counter = 0;
	int brick3Counter = 0;

	int randomBrick1;
	int randomBrick2;
	int randomBrick3;


	//Sets the scale to be the size of the level and calls the Update function
	void Start () {
		brick1Hit.transform.localScale = new Vector3 (0.06f, 0.1f, 0);
		brick2Hit.transform.localScale = new Vector3 (0.06f, 0.1f, 0);
		brick3Hit.transform.localScale = new Vector3 (0.06f, 0.1f, 0);

		randomBrick1 = Random.Range (1, 25);
		randomBrick2 = Random.Range (1, 25);
		randomBrick3 = Random.Range (1, 25);

		Update (); 
	}

	//Generates the entire level
	void Update () {

		if (brick1Counter < randomBrick1) {
			Instantiate (brick1Hit, gameObject.transform.position = new Vector3 (Random.Range (0.75f, 15.3f), Random.Range (3.5f, 11.5f), 0), Quaternion.identity);
			brick1Counter++;
		}

		if (brick2Counter < randomBrick2) {
			Instantiate (brick2Hit, gameObject.transform.position = new Vector3 (Random.Range (0.75f, 15.3f), Random.Range (3.5f, 11.5f), 0), Quaternion.identity);
			brick2Counter++;
		}

		if (brick3Counter < randomBrick3) {
			Instantiate (brick3Hit, gameObject.transform.position = new Vector3 (Random.Range (0.75f, 15.3f), Random.Range (3.5f, 11.5f), 0), Quaternion.identity);
			brick3Counter++;
		}
		Debug.Log ("Brick 1 Count = " + brick1Counter);
		Debug.Log ("Brick 2 Count = " + brick2Counter);
		Debug.Log ("Brick 3 Count = " + brick3Counter);
	}
}
