using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShip : MonoBehaviour {

	public Sprite shipDefaultSprite;
	public Sprite playerShip1;
	public Sprite playerShip2;
	public Sprite playerShip3;
	public Sprite playerShip4;
	public Sprite playerShip5;
	public Sprite playerShip6;

	private static bool movingRight = true;
	private static bool movingUp = true;
	private static bool ifIdle;
	private static bool waitDone;
	private static float xMaxEdge;
	private static float xMinEdge;
	private static float yMaxEdge;
	private static float yMinEdge;
	private static float speed = 2f;
	private static float width = 0.7f;
	private static float height = 0.7f;

	Vector3 start;
	Vector3 end;
	float timeToMove;
	float timer;

	void Start () {
		waitDone = false;

		start = new Vector3 (Random.Range (-10, 10), Random.Range (-8, -6), this.transform.position.z);
		end = new Vector3 (Random.Range (-6.5f, 6.5f), 4.8f, this.transform.position.z);
		timeToMove = 4.5f;
		timer = timeToMove;


		//GetComponent<Animator> ().Play ("FlyUp");
		ifIdle = false;

		float distanceToCamera = transform.position.z - Camera.main.transform.position.z; 
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceToCamera));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceToCamera));
		Vector3 topEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distanceToCamera));
		Vector3 bottomEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceToCamera));
		xMaxEdge = rightEdge.x;
		xMinEdge = leftEdge.x;
		yMaxEdge = topEdge.y;
		yMinEdge = bottomEdge.y;
		StartCoroutine (WaitToLoad (5f));

	}

	IEnumerator WaitToLoad (float waitTime) {
		yield return new WaitForSecondsRealtime (waitTime);
		waitDone = true;
	}

	void Update () {
		if (waitDone) {
			timer -= Time.deltaTime;

			if (timer > 0) {
				Vector3 distance = end - start;
				float degreeOfMovement = (timeToMove - timer) / timeToMove;
				transform.position = new Vector3 (start.x + (distance.x * degreeOfMovement), start.y + (distance.y * degreeOfMovement), transform.position.z);
				
			} else if (timer <= 0) {
				ifIdle = true;
			}
		}


		//moves formation
		Debug.Log (ifIdle);
		if (ifIdle) {
			if (LevelManager.currentSceneName == "Start Menu" || LevelManager.currentSceneName == "Settings" || LevelManager.currentSceneName == "Win Screen" || LevelManager.currentSceneName == "Sprite Picker") { 
				if (movingRight) {
					transform.position += Vector3.right * speed * Time.deltaTime;
				} else {
					transform.position += Vector3.left * speed * Time.deltaTime;
				}

				if (movingUp) {
					transform.position += Vector3.up * speed * Time.deltaTime;
				} else {
					transform.position += Vector3.down * speed * Time.deltaTime;
				}
			}
		}

		//controls when the formation swiches directions
		if (ifIdle) {
			float leftEdgeofFormation = transform.position.x - (0.46f * width);
			float rightEdgeofFormation = transform.position.x + (0.46f * width);
			float topEdgeofFormation = transform.position.y + (0.46f * height);
			float bottomEdgeofFormation = transform.position.y - (0.46f * height);

			if (leftEdgeofFormation < xMinEdge) {
				movingRight = true;
			} else if (rightEdgeofFormation > xMaxEdge) {
				movingRight = false;
			}
				
			if (topEdgeofFormation > yMaxEdge) {
				movingUp = false;
			} else if (bottomEdgeofFormation < yMinEdge) {
				movingUp = true;
			}
		}

		if (Settings.playerShip == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip1;
		} else if (Settings.playerShip == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip2;
		} else if (Settings.playerShip == 3) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip3;
		} else if (Settings.playerShip == 4) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip4;
		} else if (Settings.playerShip == 5) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip5;
		} else if (Settings.playerShip == 6) {
			this.GetComponent<SpriteRenderer> ().sprite = playerShip6;
		}
	}
}
