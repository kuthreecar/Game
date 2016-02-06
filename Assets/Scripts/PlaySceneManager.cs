using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaySceneManager : MonoBehaviour {

	public GameObject enemyOrgGo;
	List<GameObject> enemyArr;
	GameObject testgo;
	
	public float spawnTime = 3f;
	public float screenWidthOffset = 50;
	public float speed = 0.1f;
	
	// Use this for initialization
	void Start () {
		enemyArr = new List<GameObject>();
		//for (int i=0; i<10; i++){
			//spawn(i);
		//}
		InvokeRepeating ("spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void spawn(){
		//Debug.Log("Instantiate at " + position);
		Transform enemy = (Instantiate(enemyOrgGo) as GameObject).transform;
		float xpos = Random.Range(screenWidthOffset, Screen.width-screenWidthOffset);
		float ypos = Screen.height;
		float zpos = -1f;
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(xpos, ypos, 0));
		pos.y -= (enemy.gameObject.GetComponent<BoxCollider>().size.y)/2;
		enemy.position = new Vector3(pos.x, pos.y, zpos);
		enemyArr.Add(enemy.gameObject);
	}

	public static void addScore(int score){
		ScoreManager scoreM = GameObject.Find("Score").GetComponent<ScoreManager>();
		if (scoreM!=null){
			Debug.Log("point added by " + score);
			scoreM.addPoint(score);
		}
	}

}
