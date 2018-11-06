using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {

		timer += Time.deltaTime;
		if (timer >= 0.1) {
			Destroy(gameObject);
			timer = 0;
		}
	}
}
