﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureBaseP1G1 : MonoBehaviour {

	public static bool triggeredP1G1;
	public static string getP1Name;
	public static Vector3 baseLocation;

	void Start()
	{
		baseLocation = transform.position;
		triggeredP1G1 = false;
	//	Debug.Log("P1Base Location " + baseLocation);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player1" || other.tag == "P1SelectedUnit") 
		{
			triggeredP1G1 = true;
			getP1Name = other.name;
			Debug.Log ("On base");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		
		triggeredP1G1 = false;
		//Debug.Log ("Off base");

	}

	void Update()
	{
		StoreActiveBases.p1g1 = triggeredP1G1;
	}

}
