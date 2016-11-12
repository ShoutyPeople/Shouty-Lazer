using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour {

	// Use this for initialization
	static AsyncOperation async;
	void Start () {
		async = SceneManager.LoadSceneAsync(1);
		async.allowSceneActivation = false;
	}
	
	// Update is called once per frame
	public static void NOW () {
		async.allowSceneActivation = true;
	}
}
