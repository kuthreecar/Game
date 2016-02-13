using UnityEngine;
using System.Collections;

public class SelectSceneManager : MonoBehaviour {

	static SelectSceneManager instance;

	public bool unlockedBigAct = false;

	public string secretCode = "rclub";
	private int gotLength;

	public Color defaultColor;
	Color color1;
	Color color2;
	public float duration = 1;
	bool colorChanging;
	float startTime;

	void Awake() {
		if (instance==null) {
			instance = this;
		}
		else {
			Destroy (this);
		}
	}
	
	static public SelectSceneManager getInstance(){
		return instance;
	}

	// Use this for initialization
	void Start () {
		gotLength = 0;
		GlobalVars.team = GlobalVars.Team.Batu;
		GlobalVars.canBigAct = false;
		changeBackgroundColor (defaultColor);
		GetComponent<ShowBigAct> ().refreshSprite ();
	}
	
	// Update is called once per frame
	void Update () {

		if (colorChanging){
			changeColor();
		}

		foreach (char c in Input.inputString) {
			Debug.Log (c);
			checkChar(c);
		}
		if (Input.GetKeyDown ("escape")) {
			Debug.Log ("secretCode reset");
			disableBigAct();
			gotLength = 0;
		}
	}

	void changeColor(){
		float t = (Time.time - startTime) / duration;
		Camera.main.backgroundColor = Color.Lerp(color1, color2, t);
		if (t >= 1f) {
			colorChanging = false;
			//color1 = color2;
		}
	}
	public void changeBackgroundColor (Color _color){
		startTime = Time.time;
		colorChanging = true;
		color1 = Camera.main.backgroundColor;
		color2 = _color;
	}

	void checkChar(char c){
		if (!GlobalVars.canBigAct){
			if (c != secretCode [gotLength]) {
				gotLength = 0;
			}
			else{
				// got the code right
				gotLength ++;

				if (gotLength == secretCode.Length) {
					Debug.Log ("secretCode entered");
					enableBigAct();
				}
			}
		}
	}

	void enableBigAct(){
		//unlockedBigAct = true;
		GlobalVars.canBigAct = true;
		GetComponent<ShowBigAct> ().refreshSprite ();
	}
	void disableBigAct(){
		//unlockedBigAct = false;
		GlobalVars.canBigAct = false;
		GetComponent<ShowBigAct> ().refreshSprite ();
	}

}
