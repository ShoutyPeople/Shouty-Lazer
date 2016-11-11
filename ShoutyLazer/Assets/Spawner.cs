using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public int Amount;
	public GameObject prefab;
	public float Range;

	public float rate;

	List<GameObject> spawned;
	float countDown = 1;

	int checky = 0;

	// Use this for initialization
	void Start () {
		spawned = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (countDown<0){
			if (spawned.Count<Amount){
				Spawn();
			}
		} else {
			countDown-=rate*Time.deltaTime;
		}
		if (spawned.Count>0){
			checky = (checky+1)%spawned.Count;
			if (spawned[checky]==null){
				spawned.RemoveAt(checky);
			}
		}
	}


	void Spawn(){
		GameObject go = (GameObject) GameObject.Instantiate(prefab, transform.position+Random.insideUnitSphere*Range, Quaternion.identity);
		spawned.Add(go);
		countDown = 1;
	}
}
