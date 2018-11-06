using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovment : MonoBehaviour {

	Rigidbody2D rb;
	float speed;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		speed = UnityEngine.Random.Range(-4, -15);
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
