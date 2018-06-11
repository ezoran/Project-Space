using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureBaseP2G2 : MonoBehaviour {

	public static bool triggeredP2G2;
	public static string getP2Name;
	public static Vector3 baseLocation;

	void Start()
	{
		baseLocation = transform.position;
		triggeredP2G2 = false;

		//Debug.Log("P2Base Location " + baseLocation);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player2" || other.tag == "P2SelectedUnit") 
		{
			triggeredP2G2 = true;
			getP2Name = other.name;
			Debug.Log ("On base");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		triggeredP2G2 = false;
		//Debug.Log ("Off base");

	}

	void Update()
	{
		StoreActiveBases.p2g2 = triggeredP2G2;
	}

}