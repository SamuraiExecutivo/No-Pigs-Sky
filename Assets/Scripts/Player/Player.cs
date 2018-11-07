using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	public GameObject healthBar;
	public GameObject FuelBar;
	public static float playerHealth;
	public static float fuel;
	public static float maxFuel = 250;
	public static float maxHealth = 100;
	private float fuelLoss;
	private bool fuelOverheat;
	private Rigidbody2D rb;
	public float maxspeed;
	private float speed;
	public LayerMask hitPlayer;
	public float deathtimer;
	public AudioSource audioSource;
	public AudioClip explodeclip;
	public bool invencible;
	
	float vert;
	float hori;

	// Use this for initialization
	void Start () {
		invencible = true;
		rb = GetComponent<Rigidbody2D>();
		speed = maxspeed;
		playerHealth = 100;
		fuel = maxFuel;
		fuelLoss = 0.60f;
		audioSource = GetComponent<AudioSource>();
		if (invencible) {
			rb.gravityScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fuel > maxFuel) {
			fuel = maxFuel;
		}

		if (transform.position.y <= -10 || transform.position.x < -16 || transform.position.x > 17) {
			deathtimer += Time.deltaTime;
			if (deathtimer >= 1) {
				GameOver();
			}
		}

		if (GameStart.isStarted) {
			invencible = false;
			rb.gravityScale = 30;
		}
	}

	void FixedUpdate () {

		if (fuel > 1 && GameStart.isStarted) {
			vert = Input.GetAxis("Vertical");
			hori = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(hori * speed, vert * speed);
			FuelConsumption();
		}

		if (fuel <= 2) {
			fuelOverheat = true;
			speed = 0;
		}

		if (fuel >= 50 && fuelOverheat == true) {
			fuelOverheat = false;
			speed = maxspeed;
		}

	}

	void FuelConsumption () {
		
		if (Input.GetAxis("Vertical") > 0) {
			fuel -= fuelLoss;
		}

		if (Input.GetAxis("Horizontal") > 0) {
			fuel -= fuelLoss;
		}
		
		if (Enemy.destroyedByPlayer == true) {
			Enemy.destroyedByPlayer = false;
		}
	}

	public static void FuelingUp (float gain) {
		fuel += gain;
	}

	void DamagingPlayer (int damage) {
		playerHealth -= damage;
		if (playerHealth <= 0) {
			audioSource.PlayOneShot(explodeclip);
			GameOver();
		}
	}

 	void GameOver () {
		 if(!invencible) {
			Destroy (gameObject);
			SceneManager.LoadScene("MainScene");
		 }
	} 

	void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Enemy"){
    		DamagingPlayer (30);
        }
		if (collision.gameObject.tag == "Alien"){
			DamagingPlayer (60);
		}
    }
}
