using UnityEngine;
using System.Collections;

public class SkipPhaseAfterSeconds : MonoBehaviour {

	public int phaseToSkip;
	public float seconds;	
	float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Phases.currentPhase == phaseToSkip){
			time+=Time.deltaTime;
			if (time>seconds){
				Phases.Skip();
			}
		}
	}
}
