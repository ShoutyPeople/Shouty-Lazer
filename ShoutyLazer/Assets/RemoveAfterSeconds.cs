using UnityEngine;
using System.Collections;

public class RemoveAfterSeconds : MonoBehaviour {

	// Use this for initialization
	public float seconds;
	void Start () {
		StartCoroutine(Remove());
	}

	IEnumerator Remove(){
		yield return new WaitForSeconds(seconds); 
		GameObject.Destroy(this.gameObject);
	}
}
