using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigActAnim : MonoBehaviour {

	List<Animator> animList;

	// Use this for initialization
	void Start () {
		animList = new List<Animator>();
		for (int i=0; i<this.transform.childCount;i++){
			Animator childAnim =this.transform.GetChild(i).gameObject.GetComponent<Animator>();
			animList.Add(childAnim);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playAnim(){
		foreach (Animator anim in animList) {
			anim.SetTrigger("trigger");
		}

	}

}
