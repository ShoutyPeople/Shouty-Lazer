using UnityEngine;
using System.Collections;

public class ScaleByShoutPower : MonoBehaviour {

	public float power = 1;
	Vector3 baseScale;
	// Use this for initialization
	void Start () {
		baseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale=baseScale*Mathf.Pow(ShoutInput.ShoutPowerf,power);
	}
}
