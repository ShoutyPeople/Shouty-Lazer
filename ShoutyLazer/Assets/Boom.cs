using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {

	public float boomTime;
	public GameObject boomBit;
	public float boomSpeed;

	public float initRadius;
	public float initCount;

	float time = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i<initCount; i++){
			GameObject.Instantiate(boomBit,transform.position+Random.onUnitSphere*initRadius, Random.rotation);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time += Time.deltaTime;
		Vector2 circ = Random.insideUnitCircle.normalized*(initRadius+boomSpeed*(time*time));
		GameObject.Instantiate(boomBit,
			transform.position+Quaternion.AngleAxis(Random.Range(0,360),transform.up)*new Vector3(circ.x, 0, circ.y),
			Random.rotation);
		if (time>boomTime){
			enabled = false;
		}
	}
}
