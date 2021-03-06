﻿using UnityEngine;
using System.Collections;

public class EnemyScript : EnemyType {

	//public int score = 3;
	//public float speed = 1.1f;
	private bool isDetached = false;
	public int newScore = 6;
	// Use this for initialization
	void Start () {
		isDetached = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDetached) {
			//move down by itself
			moveDown (transform, speed);
		}
	}
	
	void OnMouseDown(){
		//Debug.Log ("Enemy killed " + this);
		if (!PlaySceneManager.getInstance().gameEnds) getMurdered ();
	}

	public void getMurdered(){
		//Debug.Log ("is killed=" + isKilled);
		if (!isKilled) {
			isKilled = true;

			Transform gop = transform.parent;
			bool successp = true;
			if (gop != null) {
				successp = gop.GetComponent<CoupleType> ().childDestroy ();
			}

			if (successp) {
				string scoreText = "+" + score;
				PlaySceneManager.addScore (score);
				PlaySceneManager.getInstance().instantiateScoreText(transform.localPosition, scoreText);
				dies ();

			}
		}

	}

	void cpDetach(){
		if (!isKilled) {
						isDetached = true;
						score = newScore;
				}
	}

}
