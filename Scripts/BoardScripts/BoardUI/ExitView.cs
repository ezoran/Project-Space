using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitView : MonoBehaviour {

	public GameObject exitPopup;

	bool isVisible;
	// Use this for initialization
	void Start () {
		isVisible = false;
		exitPopup.SetActive (false);
	}

	public void showText()
	{
		if (isVisible == false)
		{
			isVisible = true;
			exitPopup.SetActive (true);
		} else if (isVisible == true)
		{
			isVisible = false;
			exitPopup.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
