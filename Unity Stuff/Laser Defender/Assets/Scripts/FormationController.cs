using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour {

	public GameObject enemyPreFab;

	private bool movingRight = true;
	private float xMinEdge;
	private float xMaxEdge;

	float width = 12f;
	float height = 6f;
	float speed = 1f;

	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z; 
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceToCamera));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceToCamera));
		xMaxEdge = rightEdge.x;
		xMinEdge = leftEdge.x;
		SpawnUntilFull ();
	}

	//Spawns enemies
	void SpawnEnemies () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPreFab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	//Spawns Individual Enemies
	void SpawnUntilFull () {
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPreFab,freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", 0.5f);
		}
	}

	//shows formation edge in scene view
	public void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	//Checks if there are any spots for the enemy to spawn in
	Transform NextFreePosition () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	//Checks if all the enemies are dead
	bool AllMembersDead () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void Update () {

		//moves formation
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		//controls when the formation swiches directions
		float leftEdgeofFormation = transform.position.x - (0.46f * width);
		float rightEdgeofFormation = transform.position.x + (0.46f * width);
		if (leftEdgeofFormation < xMinEdge) {
			movingRight = true;
		} else if (rightEdgeofFormation > xMaxEdge) {
			movingRight = false;
		}

		if (AllMembersDead ()) {
			SpawnUntilFull ();
		}
	}
}
