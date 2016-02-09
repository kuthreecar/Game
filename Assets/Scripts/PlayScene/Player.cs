using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerHealth=100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reduceHealth(int value){
		playerHealth -= value;
		if (playerHealth <= 0) {
			PlaySceneManager.endGame();
		}
	}
	public int getHealth(){
		return playerHealth;
	}

}
