using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
	
	public static float ammoOverheat;
	public static float missileOverHeat;
	public static float maxmissile;
	public static float maxAmmo = 50;
	public float fireRate;
	public static float damage;
	public LayerMask hitObjects;
	public GameObject bulletPrefab;
	public float bulletSpeed;
	private Enemy enmScript;
	public int rotationOffSet  = 0;
	float timeToFire = 0;
	[SerializeField] Transform firePoint;
	public GameObject explosion;
	public GameObject firegun;
	public AudioSource audioSource;
	public AudioClip shootclip;
	
	
	void Awake () {
		damage = 25;
		ammoOverheat = maxAmmo;
		bulletSpeed = 10;
		maxmissile = 2;
		missileOverHeat = 2;
		audioSource = GetComponent<AudioSource> ();
		fireRate = 20;
	}
	
	void Update () {

		Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		diff.Normalize ();

		float rotZ = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		//Debug.Log ("Angle: " + rotZ);

		//if (rotZ < 80 && rotZ > -80) {
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ - rotationOffSet);
		//}

		if (Input.GetButton ("Fire1") && ammoOverheat >= 1 && Time.time > timeToFire && GameStart.isStarted) {
			timeToFire = Time.time + 1 / fireRate;
			Shoot();
			ammoOverheat -= 1;
		}

		if (Input.GetButtonDown ("Fire2") && missileOverHeat >= 1 && GameStart.isStarted) {
			BulletShoot();
			missileOverHeat -= 1;
		} 
	}

	void FixedUpdate () {
		if (ammoOverheat < maxAmmo) {
			ammoOverheat += 10f * Time.deltaTime;
		}
		if (missileOverHeat < maxmissile) {
			missileOverHeat += 0.1f * Time.deltaTime;
		}
	}

	void Shoot () {
		audioSource.PlayOneShot(shootclip);
		Vector2 mousePosition = new Vector2 (
			Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
			Camera.main.ScreenToWorldPoint (Input.mousePosition).y
		);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, hitObjects);
		Debug.DrawLine (firePointPosition, (mousePosition - firePointPosition) * 100, Color.blue);
		
		Instantiate(firegun, new Vector3(firePoint.position.x, firePoint.position.y, 0), Quaternion.identity);

		if(hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.blue);
			enmScript = hit.collider.gameObject.GetComponent<Enemy>();
			Vector2 hitPoint = hit.point;
            Instantiate(explosion, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
			enmScript.ApplyDamage(damage);
			//ammoOverheat--;
		}
	}

	void BulletShoot () {
		
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Instantiate (bulletPrefab, firePointPosition, firePoint.rotation);
	
//		Destroy(bulletPrefab, 4f);
	}

}
