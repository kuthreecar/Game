using UnityEngine;
using System.Collections;

public class SelectSceneManager : MonoBehaviour {

	public bool unlockedBigAct = false;

	public string secretCode = "rclub";
	private int gotLength;
	// Use this for initialization
	void Start () {
		gotLength = 0;
	}
	
	// Update is called once per frame
	void Update () {
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

	void checkChar(char c){
		if (!unlockedBigAct){
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
		unlockedBigAct = true;
		GlobalVars.canBigAct = true;
	}
	void disableBigAct(){
		unlockedBigAct = false;
		GlobalVars.canBigAct = false;
	}

}
