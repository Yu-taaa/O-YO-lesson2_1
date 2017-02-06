using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//移動のスピード
	public float speedX;
	public float speedZ;

	//弾
	public GameObject bullet;
	float bulletInterval;

	// Use this for initialization
	void Start () {
		bulletInterval = 0;
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
			MoveToLeft (horizontal);
		}
		if (Input.GetKey ("left")) {
			MoveToLeft (horizontal);
		}
		if (Input.GetKey ("down")) {
			MoveToBack (vertical); 
		}

		//弾の生成
		bulletInterval += Time.deltaTime;
		if (Input.GetKey ("space")) {
			if (bulletInterval >= 0.2f) {
				print("発射！");
				GenerateBullet ();
			}
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

	//弾を生成するためのメソッド
	void GenerateBullet(){
		bulletInterval = 0.0f;
		Instantiate (bullet, transform.position, Quaternion.identity);
		//ここのtransform.positionはplayerの位置
	}

}