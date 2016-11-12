using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour {

	Vector3 center;

	public float mawWait;
	public float zone;
	public float speed;
	public float range;
	public float bHeight;
	public float bFreq;

	float bOff;

	float wait;
	Vector3 walk;
	Vector3 target;

	float angle;
	Quaternion tQuat;

	// Use this for initialization
	void Start () {
		bOff = Random.value*Mathf.PI*2;
		center = transform.position;
		newTarget();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance(transform.position.xz(),target.xz())>range){
			transform.position+=walk*Time.deltaTime;
			transform.position = new Vector3(
				transform.position.x,
				center.y+Mathf.Abs(Mathf.Sin(bOff+Time.time*Mathf.PI*bFreq)*bHeight),
				transform.position.z
			);
			
			transform.rotation = Quaternion.Slerp(
				transform.rotation,
				tQuat,
				10*Time.deltaTime
			);
		} else {
			transform.position = new Vector3(
				transform.position.x,
				center.y,
				transform.position.z
			);
			wait-=Time.deltaTime;
			if (wait<0){
				newTarget();
			}
		}
	}

	void newTarget(){
		Vector2 circ = Random.insideUnitCircle*zone;
		target = new Vector3(
			center.x+circ.x,
			center.y,
			center.z+circ.y
		);
		walk = (target-transform.position).normalized*speed;
		wait = Random.value*mawWait;
		angle = Mathf.Atan2(-walk.z,walk.x)*Mathf.Rad2Deg+90;
		tQuat = transform.rotation;
		tQuat.eulerAngles = new Vector3(
			tQuat.eulerAngles.x,
			angle,
			tQuat.eulerAngles.z
		);
	}

	void OnDrawGizmos(){
		int step = 10;
		Vector3 c;
		if (Application.isPlaying){
			c = center;
		} else {
			c = transform.position;
		}
		for (int i = 0; i<= 360; i+=step){
			Gizmos.color = Color.red;
			Gizmos.DrawLine(
				c+Quaternion.AngleAxis(i,Vector3.up)*Vector3.right*zone,
				c+Quaternion.AngleAxis(i+step,Vector3.up)*Vector3.right*zone
			);
		}
	}

}
