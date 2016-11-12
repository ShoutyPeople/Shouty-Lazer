using UnityEngine;
using System.Collections;

public class Asplode : MonoBehaviour {

	public float hp = 1;
	public GameObject effects;
	public float dieIn;
	public float upVel;
	public float spinSpeed;

	Vector3 axis;
	// Use this for initialization
	void Start () {
		axis = Random.onUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp<0){
			Quaternion rot = Quaternion.AngleAxis(spinSpeed*Time.deltaTime,axis);
			transform.rotation = rot*transform.rotation;

			dieIn-=Time.deltaTime;
			if (dieIn<=0)
				GameObject.Destroy(this.gameObject);
			upVel+=Physics.gravity.y*Time.deltaTime;
			transform.position+=Vector3.up*upVel*Time.deltaTime;
		}
	}
	void Hit(){
		hp-=Time.fixedDeltaTime;
		if (hp<0){
			effects.SetActive(true);
		}
	}

}
