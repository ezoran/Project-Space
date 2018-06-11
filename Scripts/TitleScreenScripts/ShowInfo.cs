using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Shows game info when "info" button is pressed -- Attatched to HandleButtons objects

public class ShowInfo : MonoBehaviour {
	
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
	}
}
