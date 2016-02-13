using UnityEngine;
using System.Collections;

public class BigActEvent : MonoBehaviour {

	public float animationTime = 1.0F;

	// Use this for initialization
	void Start () {
		StartCoroutine (endAnimation ());
	}

	IEnumerator endAnimation(){
		yield return new WaitForSeconds(animationTime);
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
