using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	private float hue;

	void Start() {
		hue = Random.Range(0.0f, 1.0f);	
	}

	// Update is called once per frame
	void Update () {
		hue += 0.01f * Time.deltaTime;
		hue %= 1.0f;
		this.GetComponent<Renderer>().material.color = Color.HSVToRGB(hue, 0.5f, 1f);
	}
}
