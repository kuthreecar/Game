using UnityEngine;
using System.Collections;

public class CoupleType : EnemyType {

	//public float speed = 1f;
	//public int score = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		moveDown (transform, speed);
	}

	void OnMouseDown(){
		//Debug.Log("mouse clicked");
		if (!PlaySceneManager.getInstance().gameEnds) getMurdered ();
	}

	public bool childDestroy(){
		if (!isKilled) {
			isKilled = true;
			gameObject.BroadcastMessage ("cpDetach");
			transform.DetachChildren ();
			Destroy (gameObject);
			return true;
		}
		else{
			return false;
		}
	}

	public void getMurdered(){
		if (!isKilled) {
			isKilled = true;
			string scoreText = "+" + score;
			PlaySceneManager.addScore (score);
			PlaySceneManager.getInstance().instantiateScoreText(transform.position, scoreText);
			dies ();
		}
	}
}
