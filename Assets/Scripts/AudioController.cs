using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	// Use this for initialization

	public AudioClip intro;
	public AudioClip loop;
	public AudioClip fight;
	public AudioClip end;
	public AudioClip boos;
	public AudioClip full;

	public AudioSource musica;
	float timer;
	
	void Start () {
		musica = GetComponent<AudioSource> ();
		musica.clip = full;
		musica.Play();

	}
	
	// Update is called once per frame
	void Update () {

		
		
	}

	void FixedUpdate () {
		timer += 1 * Time.deltaTime;
	}
}
