using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour {

	public GameObject hurt;

	public GameObject Explosion;

	public GameObject drop;

	public float dieIn;
	public float accel;
	public float friction;
	public float minDistance;
	public float maxDistance;

	public float turnLerp;

	public float life;
	public float timeToRemove;

	public Vector3 offset;

	Vector3 vel;
	Quaternion rotation;

	bool killed;

	// Use this for initialization
	void Start () {
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (life>0){
			Vector3 forward = rotation*Vector3.forward;
			vel+=(forward*accel-vel*friction)*Time.deltaTime;
			transform.position+=vel*Time.deltaTime;
			if (Vector3.Distance(offset, transform.position)>maxDistance){
				rotation = Quaternion.Slerp(rotation, Quaternion.LookRotation((offset-transform.position).normalized),turnLerp*Time.deltaTime);
			} else if (Vector3.Distance(offset, transform.position)<minDistance){
				rotation = Quaternion.Slerp(rotation, Quaternion.LookRotation((transform.position-offset).normalized),turnLerp*Time.deltaTime);
			}
			transform.rotation = Quaternion.LookRotation(vel.normalized);
		} else {
			dieIn-=Time.deltaTime;
			hurt.SetActive(true);
			vel+=Physics.gravity*Time.deltaTime;
			transform.position+=vel*Time.deltaTime;
			transform.rotation = Quaternion.LookRotation(vel.normalized);

			if (dieIn<=0){
				drop.transform.parent = null;
				drop.AddComponent<RemoveAfterSeconds>().seconds=5;
				GameObject.Instantiate(Explosion,transform.position, transform.rotation);
				GameObject.Destroy(this.gameObject);
			}

		}
	}

	void Hit(RaycastHit rch){
		life-=Time.fixedDeltaTime*ShoutInput.ShoutPower;
	}

}
