using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan_View : MonoBehaviour {
	private Animator animator;
	public string[] animations;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {
		transform.rotation = Quaternion.Euler (0, 0, 0);
	}

	//前に進む処理
	IEnumerator Run(){
		//float speed = GetComponent<UnityChan_Model> ().forward_speed;
		bool isRun = GetComponent<UnityChan_Model> ().isRun;
		while (isRun) {
			float speed = GetComponent<UnityChan_Model> ().forward_speed;
			transform.position += new Vector3 (0, 0, speed);
			isRun = GetComponent<UnityChan_Model> ().isRun;
			yield return new WaitForSeconds (0.01f);
		}
	}

	//後ろに戻る処理
	IEnumerator Back(){
		float speed = GetComponent<UnityChan_Model> ().back_speed;
		bool isBack = GetComponent<UnityChan_Model> ().isBack;
		while (isBack) {
			transform.position += new Vector3 (0, 0, -speed);
			isBack = GetComponent<UnityChan_Model> ().isBack;
			yield return new WaitForSeconds (0.01f);
		}
	}

	//横に移動する処理
	public void Slide(float parameter){
		float speed =  parameter * GetComponent<UnityChan_Model> ().slide_speed;
		transform.position += new Vector3 (speed, 0, 0);
	}

	//ジャンプする処理
	IEnumerator Jump(){
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<CapsuleCollider> ().isTrigger = true;
		GetComponent<SphereCollider> ().isTrigger = false;

		yield return new WaitForSeconds (1.0f);

		animator.SetBool ("isJump", false);
		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<CapsuleCollider> ().isTrigger = false;
		GetComponent<SphereCollider> ().isTrigger = true;
	}

	//アニメーション変更処理
	public void ChangeAnimation(string animationflag){
		for (int i = 0; i < animations.Length; i++) {
			animator.SetBool (animations[i], false);
		}
		animator.SetBool (animationflag, true);

	}

	public void ChangeOneAnimation(string animationflag){
		animator.SetBool (animationflag, true);
	}


}
