using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {
	
	public AudioClip[] audioClip;
	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource> ().Play ();
	}


	// Use this for initialization
	void Start () {
		int i = audioClip.Length;
		Debug.Log (i);
		PlaySound (Random.Range(0, i));
	}


}
