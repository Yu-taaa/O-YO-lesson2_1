using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speedX;
	public float speedZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//移動
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");
		if (Input.GetKey ("up")) {
			MoveToUp (vertical);
		}
		if (Input.GetKey ("right")) {
			MoveToRight (horizontal);
		}
		if (Input.GetKey ("left")) {
			MoveToLeft (horizontal);
		}
		if (Input.GetKey ("down")) {
			MoveToBack (vertical); 
		}
		
	}

	//移動するためのメソッド
	void MoveToUp(float vertical){
		transform.Translate(0, 0, vertical * speedZ);
	}

	void MoveToRight(float horizontal){
		transform.Translate(horizontal * speedX, 0, 0);
	}

	void MoveToLeft(float horizontal){
		transform.Translate(horizontal * speedX, 0, 0);
	}

	void MoveToBack(float vertical){
		transform.Translate(0, 0, vertical * speedZ);
	} 
}
