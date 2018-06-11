using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIntroSong : MonoBehaviour {

	AudioSource audio;
	public AudioClip intro;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.clip = intro;
		audio.Play();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
