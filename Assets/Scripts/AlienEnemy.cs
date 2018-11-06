using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemy : MonoBehaviour {
	public float health;
	public Rigidbody2D rb2d;
	public float speed;
	private float maxspeed = 4f;
	public static bool destroyedByPlayer;
	public static bool abducting;
	public GameObject fuelObj;
	private Fuel drop = new Fuel();

	void Update () {
		if (transform.position.x <= -12.5) {
			abducting = true;
		}
		if (transform.position.x < -20) {
			SelfDestruct ();
		}
		if (health <= 0) {
			destroyedByPlayer = true;
			SelfDestruct ();
		}
	}
	void FixedUpdate ()  {
		if (abducting == false) {
			rb2d.velocity = new Vector2(-speed, 0);
		}
	}
	void SelfDestruct () {
//		Debug.Log ("Destroyed");
		Destroy (gameObject);
		Vector3 thisPoint = new Vector3 (rb2d.position.x, rb2d.position.y, 0);
		if (destroyedByPlayer) {
			drop.SpawnFuel(thisPoint, fuelObj);
			//PlayerWeapon.ammoOverheat++;
		}
	}

	public void ApplyDamage (float danin) {
		health -= danin;
	}
	void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            SelfDestruct();
        }
    }


}
