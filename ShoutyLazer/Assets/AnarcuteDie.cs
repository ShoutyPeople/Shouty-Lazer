using UnityEngine;
using System.Collections;

public class AnarcuteDie : MonoBehaviour {

	public float hp;
	public float sideways;

	public float upwards;

	public float rotation;

	Vector3 velocity;
	Vector3 axis;
	// Use this for initialization
	void Start () {
		axis = Random.onUnitSphere;
		Vector2 side = Random.insideUnitCircle.normalized*sideways;
		velocity = new Vector3(
			side.x,
			upwards,
			side.y
		);
	}
	
	// Update is called once per frame
	void Update () {
		if (hp<0){
			float angle = rotation*Time.deltaTime;
			transform.rotation = Quaternion.AngleAxis(angle, axis);
			transform.position+=velocity*Time.deltaTime;
			velocity+=Physics.gravity*Time.deltaTime;
			if (velocity.y<=0){

				GameObject.Destroy(gameObject);
			}
		}
	}


	void Hit(RaycastHit rch){
		hp-=Time.fixedDeltaTime;
	}
}
