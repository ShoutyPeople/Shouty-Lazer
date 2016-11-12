using UnityEngine;
using System.Collections;

public class AnarcuteDie : MonoBehaviour {

	public MonoBehaviour stop;
	public GameObject trail;
	public GameObject pop;
	public float hp;
	public float sideways;

	public float upwards;

	public float rotation;

	public float trailInter;

	float trailTime;

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
			stop.enabled=false;
			float angle = rotation*Time.deltaTime;
			transform.rotation = Quaternion.AngleAxis(angle, axis);
			transform.position+=velocity*Time.deltaTime;
			velocity+=Physics.gravity*Time.deltaTime;

			trailTime-=Time.deltaTime;
			if (trailTime<=0){
				GameObject.Instantiate(trail, transform.position, transform.rotation);
				trailTime = trailInter;
			}

			if (velocity.y<=0){
				GameObject.Instantiate(pop, transform.position, transform.rotation);
				GameObject.Destroy(gameObject);
			}
		}
	}


	void Hit(RaycastHit rch){
		hp-=Time.fixedDeltaTime;
	}
}
