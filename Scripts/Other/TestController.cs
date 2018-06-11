using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("P2-A-Button")){
			Debug.Log ("P2 Key Pressed");
		}

		if(Input.GetButtonDown("P1-A-Button")){
			Debug.Log ("P1 Key Pressed");
		}

	}
}
