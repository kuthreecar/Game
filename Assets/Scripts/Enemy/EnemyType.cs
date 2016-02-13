using UnityEngine;
using System.Collections;

public class EnemyType : MonoBehaviour {

	public int score = 3;
	public float speed = 1.1f;
	public int enemyId = 0;
	public int attackPt = 10;

	protected bool isKilled = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setId (int id){
		enemyId = id;
		this.gameObject.name = this.gameObject.name + enemyId;
		for (int i = 0; i < this.transform.childCount; ++i)
		{
			GameObject childGo =this.transform.GetChild(i).gameObject;
			childGo.name = childGo.name + enemyId;
		}
	}

	protected void moveDown(Transform trans, float speed){
		if (!GamePause.isPause()){
			Vector3 temppos = trans.position;
			PlaySceneManager psm = PlaySceneManager.getInstance (); 
			if (psm != null) {
				speed *= (psm.totalSpeed/100);
			}
			
			//Debug.Log ("movedown at speed " + speed);
			temppos.y -= speed;
			trans.position = temppos;
			
			//Vector3 transpos = Camera.main.WorldToScreenPoint (trans.position);
			BoxCollider bc= trans.GetComponent<BoxCollider> ();
			if (bc != null) {
				//if (transpos.y < - bc.size.y){
				Vector3 transpos = Camera.main.WorldToScreenPoint (bc.bounds.max);
				if ( transpos.y < 0){
					//Debug.Log ("delete gameObject with y=" + transpos.y);
					PlaySceneManager.getInstance().decreaseHealth(attackPt);
					Destroy(trans.gameObject);
				}
			}
		}
	}

	protected void dies(){
		if (isKilled) {
			Collider collider = gameObject.GetComponent<Collider>();
			if (collider!=null){
				collider.enabled = false;
			}

			Destroy (gameObject);
		}
	}

}
