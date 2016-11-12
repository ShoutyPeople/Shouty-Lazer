using UnityEngine;
using System.Collections;

public class FireLaser : MonoBehaviour {

	// Use this for initialization
	public bool beFiring;
	void Start () {
	
	}

	void FixedUpdate () {
		if (beFiring){
			RaycastHit rch;
			if (Physics.Raycast(this.transform.position, this.transform.forward, out rch, 1000)){
				rch.collider.SendMessage("Hit", rch, SendMessageOptions.DontRequireReceiver);
				rch.collider.transform.root.SendMessage("Hit", rch, SendMessageOptions.DontRequireReceiver);
				Phases.energy+=Time.fixedDeltaTime;
			}
		}
	}
}
