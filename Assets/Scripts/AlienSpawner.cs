using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour {

	public GameObject [] objectsEnemy;
	public float spawnTime;
	public Vector3 spawnPoint;
	public float spawnTimer = 0;

	// Use this for initialization
	void Start () {
		Spawn ();
		spawnTime = 6;
	}
	
	void FixedUpdate () {
		spawnTimer += 1 * Time.deltaTime;

		if (spawnTimer > spawnTime) {
			Spawn ();
			spawnTimer = 0;
		} 

		if (spawnTime > 4) {
			spawnTime -= 0.1f * Time.deltaTime;
		}
	}

	void Spawn ()
     {
         spawnPoint.x = 20;
         spawnPoint.y = Random.Range (-9, 9);
         Instantiate(objectsEnemy[UnityEngine.Random.Range(0, objectsEnemy.Length - 1)], spawnPoint, Quaternion.identity);
     }
}
