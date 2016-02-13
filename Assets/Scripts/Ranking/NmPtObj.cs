using UnityEngine;
using System.Collections;

public class NmPtObj : MonoBehaviour {

	//public int rankNo = 0;

	GameObject nameGo;
	GameObject pointGo;
	bool bold = false;

	// Use this for initialization
	void Start () {
	}

	public void setValue(int rankNo, string name, int point){
		nameGo = transform.GetChild (1).gameObject;
		pointGo = transform.GetChild (0).gameObject;
		nameGo.GetComponent<TextMesh>().text = rankNo + ". " + name;
		if (point >= 0)
						pointGo.GetComponent<TextMesh> ().text = point.ToString ();
				else 
						pointGo.GetComponent<TextMesh> ().text = "";

		if (bold) {
			//nameGo.GetComponent<TextMesh> ().fontStyle = FontStyle.Bold;
			nameGo.GetComponent<TextMesh> ().color = Color.red;
			//pointGo.GetComponent<TextMesh> ().fontStyle = FontStyle.Bold;
			pointGo.GetComponent<TextMesh> ().color = Color.red;
		}
		else{
			nameGo.GetComponent<TextMesh> ().fontStyle = FontStyle.Normal;
			nameGo.GetComponent<TextMesh> ().color = Color.white;
			pointGo.GetComponent<TextMesh> ().fontStyle = FontStyle.Normal;
			pointGo.GetComponent<TextMesh> ().color = Color.white;
		}

	}

	public void setBold(){
		bold = true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
