using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	TextMesh tm;
	void Start(){
		GlobalVars.point = 0;
		tm = GetComponent<TextMesh>();
	}
	
	public void addPoint(int value){
		GlobalVars.point += value;
		tm.text = "Score: " + GlobalVars.point;
	}
	public int getPoint(){
		return GlobalVars.point;
	}
}
