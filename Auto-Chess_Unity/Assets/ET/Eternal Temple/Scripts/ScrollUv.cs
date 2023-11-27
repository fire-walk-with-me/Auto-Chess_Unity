using UnityEngine;
using System.Collections;

public class ScrollUv : MonoBehaviour {

private Material material;
private Vector2 offset;

public float scrollX;
public float scrollY;

	// Use this for initialization
	void Start () {
	offset = new Vector2(0f, 0f);
	material = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	offset.x += Time.deltaTime * scrollX;
	offset.y += Time.deltaTime * scrollY;
	
	material.SetTextureOffset("_MainTex", offset);
	}
}
