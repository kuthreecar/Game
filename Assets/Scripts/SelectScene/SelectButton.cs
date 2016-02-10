using UnityEngine;
using System.Collections;

public class SelectButton : MonoBehaviour {

	public int bid = 0;
	public GlobalVars.Team teamid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		Debug.Log ("set choice to " + bid);
		GlobalVars.team = teamid;
		GameObject[] goArr = GameObject.FindGameObjectsWithTag ("SelectBtn");
		foreach (GameObject go in goArr){
			go.GetComponent<Animator>().SetInteger("choice", bid);
		}
	}
}
