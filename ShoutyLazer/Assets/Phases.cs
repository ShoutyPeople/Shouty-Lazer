using UnityEngine;
using System.Collections;

[System.Serializable]
public struct PhaseParameters {
	public float energyForTransition;
	public float altitude;
	public GameObject enabler;
	public GameObject disabler;
}

public class Phases : MonoBehaviour {

	public GameObject player;
	public float ascendSpeedTime;
	public static float energy;
	public float dispEnergy;
	public static int currentPhase = 0;

	public PhaseParameters[] phases;

	public float vel;

	PhaseParameters current {
		get {
			if (phases!=null && phases.Length>0){
				return phases[Mathf.Clamp(currentPhase, 0, phases.Length-1)];
			}
			Debug.LogError("Oopsie");
			return new PhaseParameters();
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = player.transform.position.y;
		h = Mathf.SmoothDamp(h, current.altitude, ref vel, ascendSpeedTime);
		player.transform.position = new Vector3(0,h,0);
		if (energy>current.energyForTransition){
			NextPhase();
		}
		dispEnergy = energy;
	}

	public void NextPhase(){
		currentPhase++;
		energy=0;
		if (current.enabler!=null){
			current.enabler.SetActive(true);
		}
		if (current.disabler!=null){
			current.disabler.SetActive(false);
		}
	}
	public static void Skip(){
		Phases ph = FindObjectOfType<Phases>();
		ph.vel = 0;
		GameObject go = ph.player;
		go.transform.position=Vector3.zero;
		ph.NextPhase();
	}
}
