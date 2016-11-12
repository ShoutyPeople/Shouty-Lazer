using UnityEngine;
using System.Collections;

public class FadeTo : MonoBehaviour {

	Renderer rend;
	Material mat;
	float time;
	Color col;
	[Range(0,1)]
	public float fadeFrom;
	[Range(0,1)]
	public float fadeTo;
	public float fadeTime;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		mat = rend.material;
		time = Time.time;
		col = mat.color;
		col.a = fadeFrom;
		mat.color = col;
	}
	
	// Update is called once per frame
	void Update () {
		float elapsed = Time.time-time;
		float lerp = Mathf.Clamp01(elapsed/fadeTime);
		col.a = Mathf.Lerp(fadeFrom, fadeTo, lerp);
		mat.color = col;
		if (col.a<=0.01 && lerp>=1){
			rend.enabled = false;
		}
	}
}
