using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigActButton : MonoBehaviour {

	public GameObject bigActGo;

	private bool enabledBtn = false;

	private float startTime;
	public float cdTime = 10;
	
	public Sprite activeBtn;
	public Sprite inactiveBtn;

	// Use this for initialization
	void Start () {
		resetCD();
		refreshSprite ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!enabledBtn && Time.time - startTime > cdTime) {
			enableBigAct();
		}
	}

	void OnMouseDown(){
		if (enabledBtn && !GamePause.isPause())
			StartCoroutine(startBigAct());
	}

	public void setBigActGo(GameObject go){
		bigActGo = go;
	}

	IEnumerator startBigAct(){
		Debug.Log ("kill it all!!");
		GamePause.pauseGame ();
		//GameObject bigAct = GameObject.Find("BigAct");
		List<BigAct> bigActArr=new List<BigAct>();
		for (int i = 0; i < bigActGo.transform.childCount; ++i)
		{
			GameObject childGo =bigActGo.transform.GetChild(i).gameObject;
			childGo.SetActive(true);

			if (childGo.GetComponent<BigAct>()!=null){
				bigActArr.Add (childGo.GetComponent<BigAct>());
			}
		}

		BigActAnim[] animArr = FindObjectsOfType (typeof(BigActAnim)) as BigActAnim[];
		foreach (BigActAnim anim in animArr){
			anim.playAnim();
		}

		yield return new WaitForSeconds (2f);
		foreach (BigAct bigAct in bigActArr) {
				bigAct.killAll ();
		}
		for (int i = 0; i < bigActGo.transform.childCount; ++i)
		{
			bigActGo.transform.GetChild(i).gameObject.SetActive(false);
		}
		GamePause.continueGame ();
		disableBigAct ();
		PlaySceneManager.getInstance ().resetTimers ();

	}

	void enableBigAct(){
		enabledBtn = true;
		//GetComponent<SpriteRenderer> ().sprite = activeBtn;
		refreshSprite ();
	}

	void disableBigAct(){
		enabledBtn = false;
		//GetComponent<SpriteRenderer> ().sprite = inactiveBtn;
		resetCD ();
		refreshSprite ();
	}

	void resetCD(){
		startTime = Time.time;
	}

	public void setBtnSprite(Sprite normalSprite, Sprite lockSprite){
		activeBtn = normalSprite;
		inactiveBtn = lockSprite;
		refreshSprite ();
	}

	void refreshSprite(){
		if (enabledBtn) {
			GetComponent<SpriteRenderer> ().sprite = activeBtn;
		} else {
			GetComponent<SpriteRenderer> ().sprite = inactiveBtn;
		}
	}

}
