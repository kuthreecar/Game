using UnityEngine;
using System.Collections;

public class RankingManager : MonoBehaviour {

	static RankingManager instance;

	private string[] nameArr;
	private int[] pointArr;

	public TextMesh names;
	public TextMesh points;

	public NameField nameField;

	void Awake() {
		if (instance==null) {
			instance = this;
		}
		else {
			Destroy (this);
		}
	}
	
	static public RankingManager getInstance(){
		return instance;
	}

	// Use this for initialization
	void Start () {
		nameArr = GlobalVars.nameArr;
		pointArr = GlobalVars.pointArr;
		initText ();

		if (checkRecord ())
			nameField.showWindow ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void initText(){
		//TextMesh textmesh = GetComponent<TextMesh> ();
		string namesResult = "";
		for(int i=0; i<nameArr.Length; i++){
			namesResult = namesResult + (i+1) + ". " + nameArr[i] + '\n';
		}
		namesResult = namesResult.Substring(0,namesResult.Length - 1);
		names.text = namesResult;

		string ptsResult = "";
		for(int i=0; i<pointArr.Length; i++){
			if (pointArr[i]>=0)
				ptsResult = ptsResult + pointArr[i] + '\n';
			else
				ptsResult = ptsResult + '\n';
		}
		ptsResult = ptsResult.Substring(0,ptsResult.Length - 1);
		points.text = ptsResult;

	}

	public void addRecord(string name, int point){
		Debug.Log ("adding record=" + name + "," + point);
		for (int i=0; i<pointArr.Length; i++){
			if (point > pointArr[i]){
				pointArr = GlobalVars.AddItemToArray<int>(pointArr, point, i);
				nameArr = GlobalVars.AddItemToArray<string>(nameArr, name, i);

				GlobalVars.pointArr = this.pointArr;
				GlobalVars.nameArr = this.nameArr;

				//Debug.Log (pointArr);
				initText();
				break;
			}
		}

	}

	bool checkRecord(){
		for (int i=0; i<pointArr.Length; i++){
			if (GlobalVars.point > pointArr[i]){
				return true;
			}
		}
		return false;
	}
}
