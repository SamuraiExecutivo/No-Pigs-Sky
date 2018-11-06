using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour {

	// Use this for initialization
	public float ammo;
	public float max;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		max = PlayerWeapon.maxAmmo;
		ammo = PlayerWeapon.ammoOverheat;
		ChangeBarSize();
	}

	public void ChangeBarSize() {
		Vector2 scale = transform.localScale;
		scale.x = (100 * ammo) / max / 100;
		transform.localScale = scale;
//		Debug.Log (""+scale.x);
	}
}
