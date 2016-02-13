using UnityEngine;
using System.Collections;

public class ShowBigAct : MonoBehaviour {

	public SpriteScript enabledBigact;
	public SpriteScript disabledBigact;

	// Use this for initialization
	void Start () {
		refreshSprite ();
	}

	public void refreshSprite(){
		if (GlobalVars.canBigAct) {
			enabledBigact.Show();
			disabledBigact.Hide();
		}
		else{
			disabledBigact.Show ();
			enabledBigact.Hide();
		}
	}

}
