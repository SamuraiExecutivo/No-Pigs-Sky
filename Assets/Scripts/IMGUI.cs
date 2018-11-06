using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour {

	// Use this for initialization
	private string boxString;
	public GameObject healthBar;
	private float maxhealth;
	public GameObject fuelBar;
	private float maxfuel;
	public GameObject ammoBar;
	private float maxammo;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		boxString = "Missile: " + PlayerWeapon.missileOverHeat;

		//maxhealth = Player.playerHealth;


	}

	void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height),boxString);
    }
}
