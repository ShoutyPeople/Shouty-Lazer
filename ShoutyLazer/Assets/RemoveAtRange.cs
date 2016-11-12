using UnityEngine;
using System.Collections;

public class RemoveAtRange : MonoBehaviour {

	Transform cam;
	public float Range = 30;

	// Use this for initialization
	void Start () {
		cam = FindObjectOfType<Camera>().transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.SqrMagnitude(cam.position-transform.position)>Range){
			Debug.Log("pop");
			GameObject.Destroy(gameObject);
		}
	}
}
