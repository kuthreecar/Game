using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = "Score: " + GlobalVars.point;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
