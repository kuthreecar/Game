using UnityEngine;
using System.Collections;

public class CustomPSceneManager : MonoBehaviour {

	public SpriteRenderer bigActSprite;
	public SpriteRenderer eyeSprite;
	public BigActButton bigActBtn;
	public SpriteRenderer backgroundSprite;
	public BigActButton bbb;

	public Sprite[] bigActSpriteArr;
	public Sprite[] eyeArr;

	public Sprite[] btnArr;
	public Sprite[] btnLockArr;

	public GameObject[] bigActArr;

	public Sprite[] backgroundArr;

	public GameObject[] bigActEventArr;

	// Use this for initialization
	void Start () {
		int arrPos = 0;
		switch (GlobalVars.team) {
		case GlobalVars.Team.Batu: 
			arrPos = 0;
			break;
		case GlobalVars.Team.Xingxin: 
			arrPos = 1;
			break;
		case GlobalVars.Team.Lanyu: 
			arrPos = 2;
			break;
		case GlobalVars.Team.Weicao: 
			arrPos = 3;
			break;
		case GlobalVars.Team.Lunhui: 
			arrPos = 4;
			break;
		}

		setScene (arrPos);
		setBackground ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setScene (int pos){
		Debug.Log ("set scene as " + pos);
		GameObject bigAct = Instantiate (bigActArr [pos]) as GameObject;
		bigActBtn.setBigActGo (bigAct);
		bigActSprite.sprite = bigActSpriteArr [pos];
		eyeSprite.sprite = eyeArr [pos];
		bbb.setBtnSprite (btnArr[pos], btnLockArr[pos]);
		bbb.setEvent (bigActEventArr[pos]);
	}

	void setBackground(){
		backgroundSprite.sprite = backgroundArr[Random.Range (0, backgroundArr.Length)];
	}
}
