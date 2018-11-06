using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	public float health;
	public float max;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		max = Player.maxHealth;
		health = Player.playerHealth;
		ChangeBarSize();
	}

	public void ChangeBarSize() {
		Vector2 scale = transform.localScale;
		scale.x = (100 * health) / max / 100;
		transform.localScale = scale;
//		Debug.Log (""+scale.x);
	}
}
