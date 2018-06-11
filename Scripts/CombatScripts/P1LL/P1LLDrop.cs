using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1LLDrop : MonoBehaviour {

	public GameObject P1LL;

	public float timeToDrop = 5;
	float timeLeft;


	// Use this for initialization
	void Start () {
		timeLeft = timeToDrop;
	}

	void resetTime()
	{
		timeLeft = timeToDrop;
	}

	void createP1LL()
	{
		Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 10.0f, 0);
		Instantiate (P1LL, position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		if (Countdown.canBegin) 
		{
			timeLeft -= Time.deltaTime;

			if (timeLeft <= 0) 
			{
				createP1LL ();
				resetTime ();
			}
		}

	}
}
