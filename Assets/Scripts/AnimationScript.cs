using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	public SpriteScript shader;

	// Use this for initialization
	void Start () {
		GamePause.pauseGame ();
		//Debug.Log (GetComponent<Animator> ().animation.clip.length);
		StartCoroutine(endAnimation ());
	}

	IEnumerator endAnimation(){
		yield return new WaitForSeconds (3.1f);
		shader.Hide();
		GamePause.continueGame ();
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void changeText(string text){
		GetComponent<TextMesh>().text = text;
	}



}
