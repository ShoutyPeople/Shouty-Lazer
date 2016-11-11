using UnityEngine;
using System.Collections;

public class ActivateOnShout : MonoBehaviour {

	public GameObject[] Objects;
	bool last = true;

	// Update is called once per frame
	void Update () {
		if (!last){
			if (ShoutInput.ShoutActive){
				foreach (GameObject go in Objects){
					go.SetActive(true);
				}
				last = true;
			}
		} else {
			if (!ShoutInput.ShoutActive){
				foreach (GameObject go in Objects){
					go.SetActive(false);
				}
				last = false;
			}
		}
	}
}
