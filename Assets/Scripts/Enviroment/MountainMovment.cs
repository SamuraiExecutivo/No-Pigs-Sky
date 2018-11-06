using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMovment : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rb;
	float speed;
	
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		speed = -5;
	}
	
	void Update () {
		rb.velocity = new Vector2(speed, 0);

		if (transform.position.x < -50) {
			SelfDestruct();
		}
	}

	void SelfDestruct () {
		Destroy (gameObject);
	}
}
