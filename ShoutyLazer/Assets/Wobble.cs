﻿using UnityEngine;
using System.Collections;

public class Wobble : MonoBehaviour {

	public float minTime;
	public float maxTime;
	public float angle;
	
	public float lerp;
	Quaternion current;
	float nextRoll;

	// Use this for initialization
	void Start () {
		Roll();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time>nextRoll){
			Roll();
		}
		transform.localRotation = Quaternion.Slerp(transform.localRotation, current, Time.deltaTime*lerp);
	}

	void Roll(){
		current = Quaternion.AngleAxis(Random.value*angle, Random.onUnitSphere);
		nextRoll = Time.time+Random.Range(minTime, maxTime);
	}
}
