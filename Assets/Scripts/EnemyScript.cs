using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int score = 3;
	public float speed = 0.11f;
	private bool isDetached = false;
	// Use this for initialization
	void Start () {
		isDetached = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDetached) {
			//move down by itself
			moveDown();
		}
	}

	void moveDown(){
		//Debug.Log("movedown at speed " + couple.speed)
		Vector3 temppos = transform.position;
		temppos.y -= speed;
		transform.position = temppos;
	}

	void OnMouseDown(){

		PlaySceneManager.addScore (score);

		Transform gop = transform.parent;
		if (gop != null) {
			gop.GetComponent<CoupleType> ().childDestroy ();
		}

		Destroy (gameObject);
	}

	void cpDetach(){
		isDetached = true;
		score = 6;
	}

}
