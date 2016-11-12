using UnityEngine;
using System.Collections;

public class ResetEverything : MonoBehaviour {


	public float seconds = 10;
	// Use this for initialization
	IEnumerator Reset () {
		yield return new WaitForSeconds(seconds);
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
