using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBar : MonoBehaviour {

	// Use this for initialization
	public float fuel;
	public float max;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		max = Player.maxFuel;
		fuel = Player.fuel;
		ChangeBarSize();
	}

	public void ChangeBarSize() {
		Vector2 scale = transform.localScale;
		scale.x = (100 * fuel) / max / 100;
		transform.localScale = scale;
//		Debug.Log (""+scale.x);
	}
}
