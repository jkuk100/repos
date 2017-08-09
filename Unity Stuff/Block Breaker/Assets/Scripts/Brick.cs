using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	//Controls various aspects of the breakable bricks

	public LevelManager levelManager;
	public Sprite[] hitSprites;
	public AudioClip firstHit;
	public AudioClip secondHit;
	public AudioClip destroy;
	public static int breakableCount = 0;
	public int maxHits;
	public GameObject smoke;

	private int spriteIndex;
	private int timesHit;
	private bool isBreakable;


	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;

		//Counts amount of breakable bricks
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
	}

	//Checks to see if brick is breakable, and runs script if it is.
	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable == true) {
			HandleHits ();
		}
	}

	//Script that handles each brick hit and the factors that rely on this info
	void HandleHits () {
		timesHit++; // Like timesHit = timesHit + 1
		if (timesHit >= maxHits) {
			Destroy (gameObject);

			if (Preferences.smokeBool == true) {
				SmokePuff ();
			}
			
			if (Preferences.sfxBool == true) {
				//Plays "Destroy" sfx if sfx toggle is true
				AudioSource.PlayClipAtPoint (destroy, Camera.main.transform.position, 0.5f);
			}
			//Counts amount of bricks left and runs LevelManager method to start next level if the amount reaches 0
			breakableCount--;
			levelManager.BrickDestroyed ();

		} else {
			//Runs LoadSprite method (from this script/class) to load other damaged sprites
			LoadSprite ();
			if (Preferences.sfxBool == true) {
				if (spriteIndex == 1) {
					//Plays "Second Hit" sfx
					AudioSource.PlayClipAtPoint (secondHit, Camera.main.transform.position, 0.8f);
				} else if (spriteIndex == 0) { 
					//Plays "First Hit" sfx
					AudioSource.PlayClipAtPoint (firstHit, Camera.main.transform.position, 1f);
				}
			}
		}
	}

	//Plays smoke upon brick destruction
	void SmokePuff () {
		var smokeMain = smoke.GetComponent<ParticleSystem> ().main;
		smokeMain.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
		Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
	}

	//Loads different textured sprites
	void LoadSprite () {
		spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
}

