using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour {
	
	public Vector2 scrollSpeed;
	Renderer rend;
	Material mat;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		mat = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
		mat.mainTextureOffset+=scrollSpeed*Time.deltaTime;
	}
}
