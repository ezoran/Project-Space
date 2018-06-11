using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {


	public GameObject pausePanel;
	public GameObject cursor;

	bool isVisible;
	// Use this for initialization
	void Start () {
		isVisible = false;
		pausePanel.SetActive (false);
	}

	public void showText()
	{
		if (isVisible == false)
		{
			isVisible = true;
			pausePanel.SetActive (true);
			cursor.SetActive (false); //freeze cursor

			Time.timeScale = 0;
		} else if (isVisible == true)
		{
			isVisible = false;
			pausePanel.SetActive (false);
			cursor.SetActive (true); //unfreeze cursor

			Time.timeScale = 1;

		}
	}

	void Update()
	{
		if (Input.GetButtonDown ("P1-Select-Button") || Input.GetButtonDown("P2-Select-Button"))
		{
			showText ();
		}
	}
}
