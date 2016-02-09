using UnityEngine;
using System.Collections;

public class BigActTest : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		StartCoroutine (playAnim());
		//anim.enabled = false;
		//InvokeRepeating ("playAnim", 1, 1);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator playAnim(){
		yield return new WaitForSeconds(1);

		anim.SetTrigger ("trigger");
	}
}
