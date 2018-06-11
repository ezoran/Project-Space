 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCurrentLocation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
		//	Debug.Log (transform.name + "-" );
			saveLocation ();

	}

	void saveLocation()
	{
		if (transform.name == "P1Captain") 
		{
			StoreLocations.P1CaptainPosition = transform.position;
		//	Debug.Log ("P1 Captain: " + StoreLocations.P1CaptainPosition);
		}
		else if (transform.name == "P1Heavy") 
		{
			StoreLocations.P1HeavyPosition = transform.position;
			//Debug.Log ("P1 Heavy: " + StoreLocations.P1HeavyPosition);

		}
		else if (transform.name == "P1Scout3") 
		{
		//	Debug.Log ("Scout 1 HIT");
			StoreLocations.P1Scout1Position = transform.position;
 		//	Debug.Log ("P1 Scout 1: " + StoreLocations.P1Scout1Position);

		}
		else if (transform.name == "P1Scout2") 
		{
			//Debug.Log ("Scout 2 HIT");

			StoreLocations.P1Scout2Position = transform.position;
			//Debug.Log ("P1 Scout 2: " + StoreLocations.P1Scout2Position);

		}
		else if (transform.name == "P2Cap") 
		{
			//Debug.Log ("Captain HIT");
			StoreLocations.P2CaptainPosition = transform.position;
			//Debug.Log ("P2 Captain: " + StoreLocations.P2CaptainPosition);

		}
		else if (transform.name == "P2Heavy") 
		{
			StoreLocations.P2HeavyPosition = transform.position;
			//Debug.Log ("P2 Heavy: " + StoreLocations.P2HeavyPosition);

		}
		else if (transform.name == "P2Scout1") 
		{
			StoreLocations.P2Scout1Position = transform.position;
			//Debug.Log ("P2 Scout 1: " + StoreLocations.P2Scout1Position);

		}
		else if (transform.name == "P2Scout2") 
		{
			StoreLocations.P2Scout2Position = transform.position;
			//Debug.Log ("P2 Scout 2: " + StoreLocations.P2Scout2Position);

		}
	}

}
