using UnityEngine;
using System.Collections;

public class NameField : MonoBehaviour {
	string stringToEdit;
	//public int point;
	Rect windowRect ;
	public float windowHeight = 210;
	public float windowWidth = 900;
	public Font custonFont;
	bool canShow = false;

	public GUISkin customskin;

	// Use this for initialization
	void Start () {
		stringToEdit = "請輸入名字...";
		//float windowHeight = 210;
		//float windowWidth = 900;
		float xpos = (Screen.width - windowWidth) / 2;
		float ypos = (Screen.height- windowHeight) / 2 ;
		windowRect = new Rect (xpos, ypos, windowWidth, windowHeight);
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.skin = customskin;
		GUI.skin.window.fontSize = 30*Screen.width/1024;
		GUI.skin.textField.fontSize = 30*Screen.width/1024;
		GUI.skin.button.fontSize = 30*Screen.width/1024;

		GUI.skin.window.alignment = TextAnchor.UpperCenter;
		//GUI.skin.textField.alignment = TextAnchor.MiddleLeft;
		GUI.skin.button.alignment = TextAnchor.LowerCenter;

		GUI.skin.font = custonFont;
		if (canShow) windowRect = GUI.Window(0, windowRect, DoMyWindow, "恭喜進入排名榜");
	}
	void OnMouseDown(){
		//Debug.Log ("text got = " + stringToEdit);
		//RankingManager.getInstance ().addRecord (stringToEdit, GlobalVars.point);
	}
	void DoMyWindow(int windowID) {
		stringToEdit = GUI.TextField(new Rect(30, 60, windowWidth - 30*2, 60), stringToEdit, 10);
		GUI.skin.textField.alignment = TextAnchor.UpperLeft;
		if (GUI.Button(new Rect((windowWidth - 150)/2, 135, 150 , 60), "輸入")){
			Debug.Log ("text got = " + stringToEdit);
			RankingManager.getInstance ().addRecord (stringToEdit, GlobalVars.point);
			canShow = false;
		}

	}

	public void showWindow(){
		canShow = true;
	}
}
