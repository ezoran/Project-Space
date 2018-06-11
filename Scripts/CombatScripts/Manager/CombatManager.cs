using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

	float p1HealthTrack;
	float p2HealthTrack;

	GameObject p1;
	GameObject p2;
		

	// Use this for initialization
	void Start () {
		p1 = GameObject.Find ("Player1");
		p2 = GameObject.Find ("Player2");


	}

	
	// Update is called once per frame
	void Update () {

        Physics2D.IgnoreLayerCollision(8, 11, true);

		p1Health p1h = p1.GetComponent<p1Health> ();
		p2Health p2h = p2.GetComponent<p2Health> ();


		p1HealthTrack = p1h.currentHealth;
		p2HealthTrack = p2h.currentHealth;



		if (p1HealthTrack <= 0 && p2HealthTrack > 0) {
			Debug.Log ("Player 2 Wins");

			StoreName.loserName = StoreName.player1inCombat;

			BoardController.instance.currentState = States.RESTORE;
			Load();

		}
		else if (p2HealthTrack <= 0 && p1HealthTrack > 0) {
			Debug.Log ("Player 1 Wins");

			StoreName.loserName = StoreName.player2inCombat;

			BoardController.instance.currentState = States.RESTORE;
			Load();

		}



	}


	public void Load()
	{
		Debug.Log ("LOOK HERE");
		Debug.Log ("Loaded Level: " + PlayerPrefs.GetInt ("Level"));
		SceneManager.LoadScene(PlayerPrefs.GetInt ("Level"));
	}
		


}
