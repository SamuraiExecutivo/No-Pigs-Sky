using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSpawner : MonoBehaviour {
	
	public GameObject [] Mountains;
	public float mountSpawnTime;
	public Vector3 mountSpawnPoint;
	public float mountSpawnTimer;
	public GameObject [] Clouds;
	public float cloudSpawnTime;
	public Vector3 cloudSpawnPoint;
	public float cloudSpawnTimer;

	public GameObject [] ftrees;
	public float ftreeSpawnTime;
	public Vector3 ftreeSpawnPoint;
	public float ftreeSpawnTimer;

	
	public GameObject [] btrees;
	public float btreeSpawnTime;
	public Vector3 btreeSpawnPoint;
	public float btreeSpawnTimer;

	void Start () {
		SpawnMount ();
		SpawnCloud ();
		SpawnTreeF ();
		SpawnTreeB ();
	}
	
	void FixedUpdate () {

		mountSpawnTime = UnityEngine.Random.Range(4, 8);
		cloudSpawnTime = UnityEngine.Random.Range(1, 4);
		ftreeSpawnTime = UnityEngine.Random.Range(0.5f, 8);
		btreeSpawnTime = UnityEngine.Random.Range(0.05f, 7);

		mountSpawnTimer += Time.deltaTime;
		cloudSpawnTimer += Time.deltaTime;
		ftreeSpawnTimer += Time.deltaTime;
		btreeSpawnTimer += Time.deltaTime;
		

		if (mountSpawnTimer > mountSpawnTime) {
			SpawnMount ();
			mountSpawnTimer = 0;
		} 

		if (cloudSpawnTimer > cloudSpawnTime) {
			SpawnCloud ();
			cloudSpawnTimer = 0;
		}

		if (ftreeSpawnTimer > ftreeSpawnTime) {
			SpawnTreeF ();
			ftreeSpawnTimer = 0;
		}
		if (btreeSpawnTimer > btreeSpawnTime) {
			SpawnTreeB ();
			btreeSpawnTimer = 0;
		}
	}

	void SpawnMount () {
         mountSpawnPoint.x = 30;
         mountSpawnPoint.y = -9.7f;
         Instantiate(Mountains[UnityEngine.Random.Range(0, Mountains.Length - 1)], mountSpawnPoint, Quaternion.identity);
     }
	void SpawnCloud () {
         cloudSpawnPoint.x = 26;
         cloudSpawnPoint.y = Random.Range (-2, 10);
         Instantiate(Clouds[UnityEngine.Random.Range(0, Clouds.Length - 1)], cloudSpawnPoint, Quaternion.identity);
     }
	 
	 void SpawnTreeF () {
		ftreeSpawnPoint.x = 26;
		ftreeSpawnPoint.y = -8.5f;
		Instantiate(ftrees[UnityEngine.Random.Range(0, ftrees.Length -1)], ftreeSpawnPoint, Quaternion.identity);
	 }

	 void SpawnTreeB () {
		btreeSpawnPoint.x = 26;
		btreeSpawnPoint.y = -9f;
		Instantiate(btrees[UnityEngine.Random.Range(0, btrees.Length -1)], btreeSpawnPoint, Quaternion.identity);
	 }
	 
}
