using UnityEngine;
using System.Collections;

public class FlashOnHit : MonoBehaviour {

	public int minHitPower = 1;
	public Renderer rend;
	Material mat;
	Texture tex;
	Color col;
	// Use this for initialization
	void Start () {
		if (rend==null)
			rend = GetComponent<Renderer>();
		mat = rend.material;
		if (mat.HasProperty("_MainTex"))
			tex = mat.mainTexture;
		if (mat.HasProperty("_Color"))
			col = mat.color;
	}
	
	// Update is called once per frame
	void Hit (RaycastHit rch) {
		if (ShoutInput.ShoutPower>=minHitPower){
			mat.mainTexture = null;
			if (mat.HasProperty("_Color"))
				mat.color = Color.white;
			if (mat.HasProperty("_MainTex"))
				rend.material = mat;
			StartCoroutine(reset());
		}
	}
	IEnumerator reset(){
		yield return new WaitForEndOfFrame();
		mat.mainTexture = tex;
		if (mat.HasProperty("_Color"))
			mat.color = col;
		if (mat.HasProperty("_MainTex"))
			rend.material = mat;
	}
}
