using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour {

	
	public GameObject player;
	float value;

	void Awake () {
		value = 30;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			if (player.transform.position.x > 0){
				//player.GetComponent<Rigidbody2D>().velocity = new Vector2 (-value, 0);
				Debug.Log ("Saiu caralho");
			} else {
				//player.GetComponent<Rigidbody2D>().velocity = new Vector2 (x: value, y: 0);
				Debug.Log ("Porra caralho buceta merda");
			}

		}

	}
}
