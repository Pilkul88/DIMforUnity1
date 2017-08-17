using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {
	public GameObject goal;
	public GameObject gameover;

	public void GameOver(){
		gameover.SetActive (true);
	}

	public void Goal(){
		goal.SetActive (true);
	}

	public void ReStart(){
		string Scene_Name = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (Scene_Name);
	}
}
