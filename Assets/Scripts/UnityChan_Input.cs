using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan_Input : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//上キーの取得
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			pushUp ();
		}

		//下キーの取得
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			pushDown ();
		}

		//左右キーの取得
		float horizontal = Input.GetAxis ("Horizontal");
		if (horizontal != 0) {
			pushRightLeft (horizontal);
		}

		//スペースキーの取得
		if (Input.GetKeyDown (KeyCode.Space)) {
			pushSpace ();
		}


		//上下キーを離したとき
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
			GetComponent<UnityChan_View>().ChangeAnimation ("");
			GetComponent<UnityChan_Model> ().isRun = false;
			GetComponent<UnityChan_Model> ().isBack = false;
		}


	}

	//上下キーを押したときの処理
	void pushUp(){
		GetComponent<UnityChan_View> ().ChangeAnimation ("isRunning");
		GetComponent<UnityChan_Model> ().isRun = true;
		GetComponent<UnityChan_View> ().StartCoroutine ("Run");
	}

	void pushDown(){
		GetComponent<UnityChan_View> ().ChangeAnimation ("isWalkback");
		GetComponent<UnityChan_Model> ().isBack = true;
		GetComponent<UnityChan_View> ().StartCoroutine ("Back");
	}

	//左右キーを押したときの処理
	void pushRightLeft(float value){
		bool isRun = GetComponent<UnityChan_Model> ().isRun;
		if (isRun) {
			GetComponent<UnityChan_View> ().Slide (value);
		}
	}

	//スペースキーを押したときの処理
	void pushSpace(){
		bool isRun = GetComponent<UnityChan_Model> ().isRun;

		if (isRun) {
			GetComponent<UnityChan_View> ().ChangeOneAnimation ("isJump");
			GetComponent<UnityChan_Model> ().isJump = true;
			GetComponent<UnityChan_View> ().StartCoroutine ("Jump");
		}
	}

}
