using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatListener : MonoBehaviour {

	bool p1g1raised;
	bool p1g2raised;
	bool p1g3raised;
	bool p2g1raised;
	bool p2g2raised;
	bool p2g3raised;

	Scene scene;

	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene ();

	}
	
	// Update is called once per frame
	void Update (){ 
		

		//Debug.Log ("Current State: " + BoardController.instance.currentState);
		//Debug.Log ("Previous State: " + StoreState.previousState);
		//
		//Debug.Log ("P2 Captain: " + StoreLocations.P2CaptainPosition);
		//Debug.Log ("P1 Scout 1: " + StoreLocations.P1Scout1Position);
	
		//Debug.Log ("p1g1 " + p1g1raised);
	//	Debug.Log ("p1g2 " + p2g1raised);


		if(BoardController.instance.currentState == States.PLAYERONETURN || BoardController.instance.currentState == States.PLAYERTWOTURN)
		{


			if (StoreActiveBases.p1g1 == true && StoreActiveBases.p2g1 == true) {
				
				StoreName.player1inCombat = CaptureBaseP1G1.getP1Name;
				StoreName.player2inCombat = CaptureBaseP2G1.getP2Name;

				Debug.Log ("Player 1: " + StoreName.player1inCombat);
				Debug.Log ("Player 2: " + StoreName.player2inCombat);

				Debug.Log ("Previous State " + BoardController.instance.currentState);

				StoreState.previousState = BoardController.instance.currentState;
				BoardController.instance.currentState = States.COMBAT;

				Save ();
				SceneManager.LoadScene (2);

			}
			else if (StoreActiveBases.p1g2 && StoreActiveBases.p2g2 == true) {
				StoreName.player1inCombat = CaptureBaseP1G2.getP1Name;
				StoreName.player2inCombat = CaptureBaseP2G2.getP2Name;


				Debug.Log ("Player 1: " + StoreName.player1inCombat);
				Debug.Log ("Player 2: " + StoreName.player2inCombat);

				StoreState.previousState = BoardController.instance.currentState;
				BoardController.instance.currentState = States.COMBAT;


				Save ();
				SceneManager.LoadScene (2);

			}
			else if (StoreActiveBases.p1g3 == true && StoreActiveBases.p2g3 == true && (scene.name == "BoardScene")) {
				StoreName.player1inCombat = CaptureBaseP1G3.getP1Name;
				StoreName.player2inCombat = CaptureBaseP2G3.getP2Name;

				Debug.Log ("Player 1: " + StoreName.player1inCombat);
				Debug.Log ("Player 2: " + StoreName.player2inCombat);

				StoreState.previousState = BoardController.instance.currentState;
				BoardController.instance.currentState = States.COMBAT;

				Save ();
				SceneManager.LoadScene (2);

			}
			else if (StoreActiveBases.p1g3 == true && StoreActiveBases.p2g3 == true && (scene.name == "TutorialBoard")) {
			    /*
                 *Add code to go to Tutorial Fight Scene 
                 */

			}
		}

	}

	public void Save()
	{
		PlayerPrefs.SetInt ("Level", SceneManager.GetActiveScene ().buildIndex);
		PlayerPrefs.Save ();
	}
}
