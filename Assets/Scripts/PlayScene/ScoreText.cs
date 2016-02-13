using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

	//public TextMesh textMesh;

	// Use this for initialization
	void Start () {
		StartCoroutine(endAnimation ());
	}
	
	IEnumerator endAnimation(){
		yield return new WaitForSeconds (0.9f);
		Destroy (gameObject);
	}

	public void setText(string score){
		this.transform.GetChild(0).GetComponent<TextMesh>().text = score;
	}

}
