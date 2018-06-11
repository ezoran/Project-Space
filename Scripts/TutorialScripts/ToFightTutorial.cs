using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFightTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (StoreActiveBases.p1g3 == true && StoreActiveBases.p2g3 == true) {
			StoreName.player1inCombat = CaptureBaseP1G3.getP1Name;
			StoreName.player2inCombat = CaptureBaseP2G3.getP2Name;

			Debug.Log ("Player 1: " + StoreName.player1inCombat);
			Debug.Log ("Player 2: " + StoreName.player2inCombat);

			StoreState.previousState = BoardController.instance.currentState;
			BoardController.instance.currentState = States.COMBAT;

			SceneManager.LoadScene (1);

		}
	}
}
