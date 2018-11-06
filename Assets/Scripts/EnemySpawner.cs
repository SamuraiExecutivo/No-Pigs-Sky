using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject [] objectsEnemy;
	public float spawnTime;
	public Vector3 spawnPoint;
	public float spawnTimer = 0;

	// Use this for initialization
	void Start () {
		spawnTime = 1f;
	}
	
	void FixedUpdate () {
		spawnTimer += 1 * Time.deltaTime;

		if (spawnTimer > spawnTime && GameStart.isStarted) {
			Spawn ();
			spawnTimer = 0;
		}  
	}

	void Spawn ()
     {
         spawnPoint.x = 20;
         spawnPoint.y = Random.Range (-4, 9);
         Instantiate(objectsEnemy[UnityEngine.Random.Range(0, objectsEnemy.Length - 1)], spawnPoint, Quaternion.identity);
     }
}
