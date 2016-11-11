using UnityEngine;
using System.Collections;

public class ScaleByShoutPower : MonoBehaviour {

	Vector3 baseScale;
	// Use this for initialization
	void Start () {
		baseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale=baseScale*ShoutInput.ShoutPower;
	}
}
