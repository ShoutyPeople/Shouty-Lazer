using UnityEngine;
using System.Collections;

public class Rotatey : MonoBehaviour {

	public Vector3 rotate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler(rotate*Time.deltaTime) * transform.localRotation; 
	}
}
