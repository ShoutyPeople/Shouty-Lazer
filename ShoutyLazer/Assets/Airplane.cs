using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour {

	public float accel;
	public float friction;
	public float minDistance;
	public float maxDistance;

	public float turnLerp;

	Vector3 vel;
	Quaternion rotation;

	// Use this for initialization
	void Start () {
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = rotation*Vector3.forward;
		vel+=(forward*accel-vel*friction)*Time.deltaTime;
		transform.position+=vel*Time.deltaTime;
		if (transform.position.magnitude>maxDistance){
			rotation = Quaternion.Slerp(rotation, Quaternion.LookRotation(-transform.position.normalized),turnLerp*Time.deltaTime);
		} else if (transform.position.magnitude<minDistance){
			rotation = Quaternion.Slerp(rotation, Quaternion.LookRotation(transform.position.normalized),turnLerp*Time.deltaTime);
		}
		transform.rotation = Quaternion.LookRotation(vel.normalized);
	}
}
