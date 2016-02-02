using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaySceneManager : MonoBehaviour {

	public GameObject enemyOrgGo;
	List<GameObject> enemyArr;
	GameObject testgo;
	
	public float speed = 0.1f;
	
	// Use this for initialization
	void Start () {
		enemyArr = new List<GameObject>();
		testgo = Instantiate(enemyOrgGo) as GameObject;
		for (int i=0; i<10; i++){
			Instantiate(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		moveDown(testgo);
	}
	
	void Instantiate(int position){
		Debug.Log("Instantiate at " + position);
		Transform enemy = (Instantiate(enemyOrgGo) as GameObject).transform;
		float xpos = (Screen.width/10)*position;
		float ypos = Screen.height;
		float zpos = 0f;
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(xpos, ypos, 0));
		pos.y -= (enemy.gameObject.GetComponent<BoxCollider2D>().size.y)/2;
		enemy.position = new Vector3(pos.x, pos.y, zpos);
		enemyArr.Add(enemy.gameObject);
	}
	
	void moveDown(GameObject go){
		Vector3 temppos = go.transform.position;
		temppos.y -= speed;
		go.transform.position = temppos;
	}
	
}
