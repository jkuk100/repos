using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour {

	public static Vector3 randomPosition;

	void Start () {
		//randomPosition = new Vector3 (Random.Range (-5.35f, 5.35f), Random.Range (-1f, 2.5f), 1f);
	}

	void OnDrawGizmos () {
		//GetComponent<Transform> ().position = randomPosition;
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}
