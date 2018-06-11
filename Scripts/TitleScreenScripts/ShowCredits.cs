using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shows game info when "start" button is pressed -- Attatched to HandleButtons objects


public class ShowCredits : MonoBehaviour {

	public GameObject infoPopup;

	bool isVisible;
	// Use this for initialization
	void Start () {
		isVisible = false;
		infoPopup.SetActive (false);
	}

	public void showText()
	{
		if (isVisible == false)
		{
			isVisible = true;
			infoPopup.SetActive (true);
		} else if (isVisible == true)
		{
			isVisible = false;
			infoPopup.SetActive (false);
		}
	}




	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("P1-Start-Button"))
		{
			showText ();
		}
	}
}
