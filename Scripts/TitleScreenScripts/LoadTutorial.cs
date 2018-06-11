using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script loads the tutorial when the "select" button is pressed -- Attatched to HandleButtons objects


public class LoadTutorial : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("P1-Select-Button"))
		{
			SceneManager.LoadScene(3);
		}
	}
}
