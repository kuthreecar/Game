using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Player player;
	private float totalLength;
	public float decreaseSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		totalLength = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		float length = transform.localScale.x;
		if ((length/totalLength)*100 > player.getHealth()){
			transform.localScale -= new Vector3(decreaseSpeed,0f,0f);
		}
	}

}
