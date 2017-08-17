using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitychan_Collision : MonoBehaviour {

	public GameObject GameManager;
	private Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		rigidbody.velocity = new Vector3(
			0,
			rigidbody.velocity.y,
			0
		);
	}

	void OnCollisionEnter(Collision other){
		string tagname = other.gameObject.tag;

		switch (tagname) {
		case "Obstacle":
			GameManager.GetComponent<manager> ().GameOver ();
			break;

		case "Goal":
			GameManager.GetComponent<manager> ().Goal ();
			break;
		
		case "Ride":
			transform.parent = other.transform;
			break;

		case "Fall":
			GameObject target = other.gameObject;
			if (!target.GetComponent<Rigidbody> ()) {
				target.AddComponent<Rigidbody> ();
			}
			break;
		}
	}

	void OnCollisionExit(Collision other){
		string tagname = other.gameObject.tag;

		switch (tagname) {
		case "Ride":
			transform.parent = null;
			break;
			
		}
	}


	void OnTriggerEnter(Collider other){
		string tagname = other.gameObject.tag;

		switch (tagname) {
		case "SpeedUp":
			GetComponent<UnityChan_Model> ().forward_speed *= 1.2f;
			other.gameObject.SetActive(false);
			break;

		case "SpeedDown":
			GetComponent<UnityChan_Model> ().forward_speed *= 0.8f;
			other.gameObject.SetActive(false);
			break;
		}

	}
}
