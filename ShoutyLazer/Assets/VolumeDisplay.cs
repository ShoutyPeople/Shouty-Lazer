using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class VolumeDisplay : MonoBehaviour {


	TextMesh tm;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		tm.text = ""+ShoutInput.SmoothedSqLoudness;
	}
}
