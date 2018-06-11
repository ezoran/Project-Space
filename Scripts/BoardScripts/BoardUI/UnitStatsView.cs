using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatsView : MonoBehaviour {

	public GameObject p1StatsPopup;
	public GameObject p2StatsPopup;

	bool isVisible;
	// Use this for initialization
	void Start () {
		isVisible = false;
		p1StatsPopup.SetActive (false);
		p2StatsPopup.SetActive (false);

	}

	public void showText()
	{
		if (isVisible == false)
		{
			
			if (BoardController.instance.currentState == States.PLAYERONETURN)
			{
				isVisible = true;
				p1StatsPopup.SetActive (true);
			}
			else if (BoardController.instance.currentState == States.PLAYERTWOTURN)
			{
				isVisible = true;
				p2StatsPopup.SetActive (true);
			}

		} else if (isVisible == true)
		{
			isVisible = false;
			p1StatsPopup.SetActive (false);
			p2StatsPopup.SetActive (false);

		}
	}
}
