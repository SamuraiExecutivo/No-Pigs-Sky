using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

	public float fuelValue;
	Rigidbody2D rbf;  
	public Vector3 spawnPoint;
	public float speed;
	void Start () {
		speed = 6;
		fuelValue = 30;
		rbf = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate ()  {
		rbf.velocity = new Vector2(-speed, 0);
	}
	void Update () {
		
	}

	public void SpawnFuel (Vector3 spawnPoint, GameObject fuelobj)
     {
         Instantiate(fuelobj, spawnPoint, Quaternion.identity);
     }

	 void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "PlayerProjectile") {
			SelfDestruct();
		}
        if (collision.gameObject.tag == "Player") {
			Player.FuelingUp(fuelValue);
            SelfDestruct();
        } 

    }
	public void SelfDestruct () {
		Debug.Log ("Fuel Destroyed");
		Destroy (gameObject);
	}
}
