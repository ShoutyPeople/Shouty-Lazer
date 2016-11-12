﻿using UnityEngine;
using System.Collections;

public class ResetEverything : MonoBehaviour {

	// Use this for initialization
	IEnumerator Reset () {
		Debug.Log ("Ye");
		yield return new WaitForSeconds(10);
		Debug.Log ("No?");
		foreach (KeepAlive ka in FindObjectsOfType<KeepAlive>()){
			GameObject.Destroy(ka.gameObject);
		}
		Phases.currentPhase=0;
		Phases.energy = 0;
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
	
	// Update is called once per frame
	void Start () {
		StartCoroutine(Reset());
	}
}
