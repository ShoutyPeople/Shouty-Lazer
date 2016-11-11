using UnityEngine;
using System.Collections;

public class BasicFPS : MonoBehaviour {

	// Use this for initialization
	public float vClamp = 85;
	public Vector2 sensitivity = Vector2.one;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rotation = transform.localRotation.eulerAngles;
		rotation.x+=Input.GetAxis("Mouse Y")*sensitivity.x;
		rotation.x = (rotation.x+180)%360-180;
		//Debug.Log(rotation.x);
		rotation.x = Mathf.Clamp(rotation.x, -vClamp, vClamp);
		rotation.y+=Input.GetAxis("Mouse X")*sensitivity.y;
		transform.rotation = Quaternion.Euler(rotation);
	}
}
