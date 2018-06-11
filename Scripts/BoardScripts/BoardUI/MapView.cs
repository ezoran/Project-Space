using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour {

	public GameObject mapPopup;

	bool isVisible;
	// Use this for initialization
	void Start () {
		isVisible = false;
		mapPopup.SetActive (false);
	}

	public void showText()
	{
		if (isVisible == false)
		{
			isVisible = true;
			mapPopup.SetActive (true);
		} else if (isVisible == true)
		{
			isVisible = false;
			mapPopup.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
