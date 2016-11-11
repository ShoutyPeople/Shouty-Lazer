using UnityEngine;
using System.Collections;

public class FireLaser : MonoBehaviour {

	// Use this for initialization
	public bool beFiring;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (beFiring){
			RaycastHit rch;
			if (Physics.Raycast(this.transform.position, this.transform.forward, out rch, 1000)){
				rch.collider.transform.root.SendMessage("VisHit", rch, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void FixedUpdate () {
		if (beFiring){
			RaycastHit rch;
			if (Physics.Raycast(this.transform.position, this.transform.forward, out rch, 1000)){
				rch.collider.transform.root.SendMessage("Hit", rch, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
