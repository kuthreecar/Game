﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaySceneManager : MonoBehaviour {

	static PlaySceneManager instance;

	public Player player;

	public GameObject enemyOrgGo;
	List<GameObject> enemyArr;
	GameObject testgo;
	
	int spawnid = 0;
	public float spawnTime = 3f;
	public float screenWidthOffset = 50;
	public float totalSpeed = 1f;
	public float btwSpriteDist = 0.1f;

	public List<GameObject> enemyOrgArr;

	void Awake() {
		if (instance==null) {
			instance = this;
		}
		else {
			Destroy (this);
		}
	}

	static public PlaySceneManager getInstance(){
		return instance;
	}

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
		if (!GamePause.isPause()){
			//Debug.Log("Instantiate at " + position);
			Transform enemy = makeEnemyGameObject ().transform;
			enemy.GetComponent<EnemyType>().setId(spawnid);
			spawnid++;
			float xpos = Random.Range(screenWidthOffset, Screen.width-screenWidthOffset);
			float ypos = Screen.height;
			float zpos = -1f;
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(xpos, ypos, 0));
			pos.y -= (enemy.gameObject.GetComponent<BoxCollider>().size.y)/2;
			enemy.position = new Vector3(pos.x, pos.y, zpos);
			enemyArr.Add(enemy.gameObject);
		}
	}

	public GameObject makeEnemyGameObject(){
		int enemyNumbers = 2;
		float xpos = 0.0f;
		float ypos = 0.0f;
		float zpos = -1.0f;

		List<GameObject> tempArr = new List<GameObject> ();
		foreach (GameObject go in enemyOrgArr) {
			tempArr.Add (go);
		}

		GameObject enemy = Instantiate(enemyOrgGo) as GameObject;
		enemy.transform.position = new Vector3 (0, 0, -1);

		for(int i = 0; i< enemyNumbers; i ++){
			GameObject ranEne = tempArr[Random.Range(0,tempArr.Count)];
			//finishedNumbers.Add(ranNum);
			Transform eneChild = (Instantiate(ranEne) as GameObject).transform;
			//eneChild.position=new Vector3(0,0,1);
			if (i==0){
				xpos = - (eneChild.GetComponent<BoxCollider>().size.x + btwSpriteDist);
			}
			else if (i==1){
				xpos =  (eneChild.GetComponent<BoxCollider>().size.x + btwSpriteDist);
			}
			Debug.Log (xpos +", "+ypos+", "+zpos);
			eneChild.position = new Vector3(xpos, ypos, zpos);
			Debug.Log ("eneChild="+eneChild.position);
			eneChild.parent = enemy.transform;
			tempArr.Remove(ranEne);
		} 

		return enemy;
		//Done.
	}

	public static void addScore(int score){
		ScoreManager scoreM = GameObject.Find("Score").GetComponent<ScoreManager>();
		if (scoreM!=null){
			//Debug.Log("point added by " + score);
			scoreM.addPoint(score);
		}
	}

	public void decreaseHealth(int value){
		player.reduceHealth (value);
	}

	public static void endGame(){
		Debug.Log ("Game Ends");
		GamePause.pauseGame();
	}


}
