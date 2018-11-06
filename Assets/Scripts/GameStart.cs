using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	public float timer;
	public static bool isStarted;
	public GameObject logo;
	void Start () {
		isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)){
			isStarted = true;
			
			Destroy (logo);
		}
		
	}
}
