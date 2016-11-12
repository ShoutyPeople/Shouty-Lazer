using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Wobble))]
public class Crumble : MonoBehaviour {

	Renderer rend;
	public GameObject Spam;
	public float spamEvery = 0.2f;
	float spamin;
	public float dieAfter = 10;
	public float hp;
	public int minPower;
	public float crumbleSpeed;
	bool crumbling = false;
	Wobble wob;
	// Use this for initialization
	void Start () {
		wob = GetComponent<Wobble>();
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (crumbling) {
			transform.position -= Vector3.up*crumbleSpeed*Time.deltaTime;
			dieAfter-=Time.deltaTime;
			spamin-=Time.deltaTime;
			if (dieAfter<0){
				GameObject.Destroy(this.gameObject);
			}
			if (spamin<0){
				spamin = spamEvery;
				Bounds b = rend.bounds;
				Vector3 at = new Vector3(
					Random.Range(b.min.x,b.max.x),
					Random.Range(b.min.y,b.max.y),
					Random.Range(b.min.z,b.max.z)
				);
				GameObject.Instantiate(Spam,at,Random.rotation);
			}
		}
	}


	void Hit(RaycastHit rch){
		if (ShoutInput.ShoutPower>=minPower){
			hp-=Time.fixedDeltaTime;
			if (hp<0){
				wob.enabled=true;
				crumbling=true;
			}
		}
	}
}
