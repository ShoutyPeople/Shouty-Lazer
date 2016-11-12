using UnityEngine;
using System.Collections;

public class SwitchSceneAfterSeconds : MonoBehaviour {

	public int switchTo;
	public float seconds;
	// Use this for initialization
	void Start () {
		StartCoroutine(Switcharoo());
	}
	
	// Update is called once per frame
	IEnumerator Switcharoo () {
		yield return new WaitForSeconds(seconds);
		UnityEngine.SceneManagement.SceneManager.LoadScene(switchTo);
	}
}
