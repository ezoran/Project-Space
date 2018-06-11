using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Exits the application when "exit" button is pressed -- Attatched to HandleButtons objects


public class ExitButtonScript : MonoBehaviour {

	public void ExitGame()
	{
		Application.Quit ();
	}
}
