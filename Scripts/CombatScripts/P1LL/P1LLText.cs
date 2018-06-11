using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1LLText : MonoBehaviour {

	public Text text;
	public float timeToDestroy;
	float timeLeft;


	// Use this for initialization
	void Start () {
		timeLeft = timeToDestroy;
	}

	public void resetTime()
	{
		timeLeft = timeToDestroy;
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) 
		{
			text.text = "";
			resetTime ();
		}
	}
}
