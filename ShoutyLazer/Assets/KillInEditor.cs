using UnityEngine;
using System.Collections;

public class KillInEditor : MonoBehaviour {

	// Use this for initialization
	public bool KillMeIfEditor = true;
	void Awake () {
		if (Application.isEditor && KillMeIfEditor){
			gameObject.SetActive(false);
		}
	}
}
