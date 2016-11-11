using UnityEngine;
using System.Collections;

public class ScaleByLoudness : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.one*ShoutInput.SmoothedLoudness;
	}
}
