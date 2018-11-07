using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	public float timer;
	public static bool isStarted;
	public GameObject logo;
	public GameObject hudGraphics;
	void Start () {
		isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Space) && !isStarted) {
			Destroy (logo);
			Instantiate(hudGraphics, new Vector3 (-10, -8, 0), Quaternion.identity);
			isStarted = true;
			
		}
		
	}
}
