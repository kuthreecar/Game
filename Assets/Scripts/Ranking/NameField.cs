using UnityEngine;
using System.Collections;

public class NameField : MonoBehaviour {
	string stringToEdit;
	//public int point;
	Rect windowRect ;
	public float windowHeight = 70;
	public float windowWidth = 300;
	bool canShow = false;
	// Use this for initialization
	void Start () {
		stringToEdit = "請輸入名字...";
		float windowHeight = 70;
		float windowWidth = 300;
		float xpos = (Screen.width - windowWidth) / 2;
		float ypos = (Screen.height- windowHeight) / 2 ;
		windowRect = new Rect (xpos, ypos, windowWidth, windowHeight);
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (canShow) windowRect = GUI.Window(0, windowRect, DoMyWindow, "排名榜");
	}
	void OnMouseDown(){
		//Debug.Log ("text got = " + stringToEdit);
		//RankingManager.getInstance ().addRecord (stringToEdit, GlobalVars.point);
	}
	void DoMyWindow(int windowID) {
		stringToEdit = GUI.TextField(new Rect(10, 20, windowWidth - 10*2, 20), stringToEdit, 10);
		if (GUI.Button(new Rect((windowWidth - 50)/2, 45, 50 , 20), "輸入")){
			Debug.Log ("text got = " + stringToEdit);
			RankingManager.getInstance ().addRecord (stringToEdit, GlobalVars.point);
			canShow = false;
		}

	}

	public void showWindow(){
		canShow = true;
	}
}
