﻿using UnityEngine;
using System.Collections;

public class CoupleType : MonoBehaviour {

	public float speed = 0.5f;
	public int score = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		moveDown();
	}
	
	void moveDown(){
		//Debug.Log("movedown at speed " + couple.speed)
		Vector3 temppos = transform.position;
		temppos.y -= speed;
		transform.position = temppos;
	}
	
	void OnMouseDown(){
		//Debug.Log("mouse clicked");
		Destroy(gameObject);
		PlaySceneManager.addScore (score);
	}

	public void childDestroy(){
		gameObject.BroadcastMessage ("cpDetach");
		transform.DetachChildren();
		Destroy (gameObject);
	}
}
