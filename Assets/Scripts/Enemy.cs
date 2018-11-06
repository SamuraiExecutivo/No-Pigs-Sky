using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour {
	public float health;
	public Rigidbody2D rb2d;
	public float speed;
	private float maxspeed;
	public static bool destroyedByPlayer;
	public GameObject fuelObj;
	private Fuel drop = new Fuel();
	public AudioSource audioSource;
	public AudioClip projHit;
	public float plain;
	public float timerplain;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		maxspeed = 16f;
		speed = maxspeed;
		health = 100;
		audioSource = GetComponent<AudioSource>();
		plain = 1.2f;
	}
	
	void Update () {
		if (transform.position.x < -20) {
			SelfDestruct ();
		}
		if (health <= 0) {
			destroyedByPlayer = true;
			SelfDestruct ();
		}
	}
	void FixedUpdate ()  {
		timerplain += Time.deltaTime;
		rb2d.velocity = new Vector2(-speed, plain);
		if (timerplain >= 0.6) {
			plain *= -1;
			timerplain = 0;
		}
	}
	void SelfDestruct () {
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
		if (collision.gameObject.tag == "PlayerProjectile") {
			audioSource.PlayOneShot(projHit);
			ApplyDamage (200);
		}
    }
}
