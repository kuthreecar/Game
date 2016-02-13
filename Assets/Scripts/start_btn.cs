using UnityEngine;
using System.Collections;

public class start_btn : MonoBehaviour {

	SpriteScript startbtn_sprite;
	SpriteScript startbtnover_sprite;
	
	public string nextLevel;

	void Start(){
		
		startbtn_sprite = transform.Find("start_btn").GetComponent<SpriteScript>();
		startbtn_sprite.Show ();
		
		startbtnover_sprite = transform.Find("start_btn_over").GetComponent<SpriteScript>();
		startbtnover_sprite.Hide();
		
	}
	
	void OnMouseEnter(){
		//if(!GamePause.isPause()){
		startbtnover_sprite.Show();
		startbtn_sprite.Hide ();
		//}
	}
	void OnMouseExit(){
		startbtnover_sprite.Hide();
		startbtn_sprite.Show ();
	}	
	void OnMouseDown(){
		//if(!GamePause.isPause())
		 Application.LoadLevel (nextLevel); 
	}	

}
