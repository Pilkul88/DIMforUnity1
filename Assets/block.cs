using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	//2.7 -3.8
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed, 0, 0);
		if (transform.position.x > 2.7f || transform.position.x < -3.8f) {
			speed *= -1;
		}
	}
}
