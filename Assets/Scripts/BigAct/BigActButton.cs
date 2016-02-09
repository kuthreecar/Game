using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigActButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		StartCoroutine(startBigAct());
	}

	IEnumerator startBigAct(){
		Debug.Log ("kill it all!!");
		GamePause.pauseGame ();
		//GameObject bigAct = GameObject.Find("BigAct");
		List<BigAct> bigActArr=new List<BigAct>();
		for (int i = 0; i < this.transform.childCount; ++i)
		{
			GameObject childGo =this.transform.GetChild(i).gameObject;
			childGo.SetActive(true);

			if (childGo.GetComponent<BigAct>()!=null){
				bigActArr.Add (childGo.GetComponent<BigAct>());
			}
		}
		yield return new WaitForSeconds (0.5f);
		foreach (BigAct bigAct in bigActArr) {
				bigAct.killAll ();
		}
		for (int i = 0; i < this.transform.childCount; ++i)
		{
			this.transform.GetChild(i).gameObject.SetActive(false);
		}
		GamePause.continueGame ();

	}
}
