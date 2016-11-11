using UnityEngine;
using System.Collections;

public class SpawnOnHit : MonoBehaviour {


	public GameObject spawnThis;
	// Use this for initialization
	void Hit(RaycastHit rch){
		GameObject.Instantiate(spawnThis, rch.point, Quaternion.identity);
	}
}
