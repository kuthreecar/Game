using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigAct : MonoBehaviour {

	List<CoupleType> cpArr;
	List<EnemyScript> enemyArr;

	// Use this for initialization
	void Start () {
		init ();
	}

	void init(){
		Debug.Log ("init arrays for BigAct");
		cpArr = new List<CoupleType> ();
		enemyArr = new List<EnemyScript> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void killAll(){
		foreach (CoupleType cp in cpArr) {
			if (cp!=null)
				cp.getMurdered();
		}

		foreach (EnemyScript enemy in enemyArr) {
			if (enemy!=null){
				enemy.getMurdered();
			}
		}
		init ();
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("trigger enter " + other.gameObject);
		if (other.gameObject.tag == "Enemy") {
			CoupleType cp = other.gameObject.GetComponent<CoupleType>();
			EnemyScript enemy = other.gameObject.GetComponent<EnemyScript>();
			if (cp!=null){
				cpArr.Add (cp);
			}
			else if (enemy!=null){
				enemyArr.Add (enemy);
			}
			//other.gameObject.SendMessage("getMurdered");
		}
	}
}
