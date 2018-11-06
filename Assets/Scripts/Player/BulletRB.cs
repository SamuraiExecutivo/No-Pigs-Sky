using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRB : MonoBehaviour {

	private Rigidbody2D brb;
	public float speed;
	private Enemy enmScript;
	public GameObject explosion;
	

	void Awake () {
		brb = GetComponent<Rigidbody2D>();
		speed = 15;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		 brb.velocity = new Vector2 (speed, 0);
		
		if (transform.position.x >= 20) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Item") {
			Vector2 hitPoint = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			Instantiate (explosion, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
			SelfDestruct();
		}
        if (collision.gameObject.tag == "Enemy") {
			Vector2 hitPoint = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			Instantiate (explosion, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
            SelfDestruct();
        } 

    }

	void SelfDestruct () {
		Destroy (gameObject);
	}
}
