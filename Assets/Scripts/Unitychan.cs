using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitychan : MonoBehaviour {

	private Animator animator;
	private CapsuleCollider CC;
	private Rigidbody rb;
	public float MaxSpeed = 0.01f;
	private float speed = 0.1f;
	private bool jumpflag;


	void Start () {
		animator = GetComponent<Animator>();
		CC = GetComponent<CapsuleCollider> ();
		rb = GetComponent<Rigidbody> ();
	}
		

	void Update () {
		transform.rotation = Quaternion.Euler (0, 0, 0);

		float ver;
		if (jumpflag) {
			ver = 1;
		} else {
			speed = 0.1f;
			ver = Input.GetAxis ("Vertical");
		}
		float hor = Input.GetAxis("Horizontal");
		if (ver > 0) {
			animator.SetBool ("isRunning", true);
			transform.position += transform.forward * speed;

			if (hor > 0) {
				transform.position += new Vector3 (0.03f, 0, 0);
			}else if(hor < 0) {
				transform.position += new Vector3 (-0.03f, 0, 0);
			}

		} else if (ver < 0) {
			animator.SetBool ("isWalkback", true);
			transform.position -= transform.forward * 0.01f;
		} else {
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isWalkback", false);
		}



		//ジャンプの処理
		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetBool ("isJump", true);
			StartCoroutine ("JumpAction");
		} else {
			animator.SetBool ("isJump", false);
		}



		//スライディングの処理	
		if (Input.GetKeyDown (KeyCode.Z)) {
			animator.SetBool ("isSliding", true);
		} else {
			animator.SetBool ("isSliding", false);
		}
	}

	IEnumerator JumpAction(){
		jumpflag = true;
		rb.useGravity = false;
		speed = 0.1f;
		yield return new WaitForSeconds (1.2f);
		speed = 0;
		yield return new WaitForSeconds (0.5f);
		rb.useGravity = true;
		jumpflag = false;
	}
}
