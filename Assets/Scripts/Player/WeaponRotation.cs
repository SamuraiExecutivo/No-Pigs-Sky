﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour {
 
	public int rotationOffSet  = 0;
	
	// Update is called once per frame
	void Update () {

		Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		diff.Normalize ();

		float rotZ = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		Debug.Log ("Angle: " + rotZ);

		transform.rotation = Quaternion.Euler (0f, 0f, rotZ - rotationOffSet);
		
	}

	
}
