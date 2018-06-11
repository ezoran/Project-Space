using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Used to check whether controllers are connected
// allowPlay connects to PlayButtonScript.cs

public class CheckActive : MonoBehaviour {

	public Text controller1;
	public Text controller2;

	public static bool allowPlay;
    string[] controllers;
	void getActiveControllers()
	{
		controllers = Input.GetJoystickNames ();
        int length = controllers.Length;
        Debug.Log(length);

		if (length == 1) 
		{
			controller1.text = "Player One:  Active";
			controller2.text = "Player Two: Not Active";
            allowPlay = false;
		}
		else if (length == 2) 
		{
			controller1.text = "Player One:  Active";
			controller2.text = "Player Two: Active";
			allowPlay = true;
		}
	}
	// Use this for initialization
	void Start () {
		allowPlay = false;
        controllers = null;

        Cursor.visible = false; //set cursor to not visible

    }

    // Update is called once per frame
    void Update () {
		getActiveControllers ();
	}
}
