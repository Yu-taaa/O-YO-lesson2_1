﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//移動のスピード
	public float speedX;
	public float speedZ;

	//弾
	public GameObject Bullet;
	float BulletInterval;

	//敵
	public GameObject enemy;
	float enemyInterval;

	// Use this for initialization
	void Start () {
		//弾のインターバル
		BulletInterval = 0.0f;
		//敵のインターバル
		enemyInterval = 0.0f;
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
		BulletInterval += Time.deltaTime;
		if (Input.GetKey ("space")) {
			if (BulletInterval >= 0.2f) {
				GenerateBullet ();
			}
		}

		//敵の生成
		enemyInterval += Time.deltaTime;
		if (enemyInterval >= 5.0f) {
			GenerateEnemy ();
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
		BulletInterval = 0.0f;
		Instantiate (Bullet, transform.position, Quaternion.identity);
	}

	//敵を生成するためのメソッド
	void GenerateEnemy(){
		Quaternion q = Quaternion.Euler(0, 180, 0);
		enemyInterval = 0.0f;
		//ランダムな場所に生成
		Instantiate(enemy, new Vector3(Random.Range(-100, 100), transform.position.y, transform.position.z + 200),q);
		//自身の目の前に生成
		Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z + 200),q);
	}

}
