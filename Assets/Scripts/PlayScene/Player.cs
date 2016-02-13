using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerHealth=100;
	public TextMesh healthText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reduceHealth(int value){
		playerHealth -= value;
		if (playerHealth <= 0) {
			playerHealth = 0;
			PlaySceneManager.endGame();
		}
		healthText.text = playerHealth.ToString();
	}
	public int getHealth(){
		return playerHealth;
	}

}
