using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This script loads the game when "Play" is Hit if both controllers are active -- Attatched to HandleButtons objects

public class PlayButtonScript : MonoBehaviour {

	public GameObject warning;

	void Start () {
		warning.SetActive (false);
	}

	public void LoadGame()
	{
		if (CheckActive.allowPlay) {
			warning.SetActive (false);
			SceneManager.LoadScene (1);

		} 
		else if (!CheckActive.allowPlay) 
		{
			warning.SetActive (true);
		}
			
	}
}
