using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum States{
	START,
	PLAYERONETURN,
	PLAYERTWOTURN,
	COMBAT,
	RESTORE,
	ENDGAME
}


public class BoardController : MonoBehaviour {

	public static BoardController instance = null;

	public Text turnText; //handles the text on screen dealing with displaying who's turn it is
	public Text p1ScoreText;
	public Text p2ScoreText;
	public Text distanceCheck;


	public GameObject victorPopup;
	public Text victor;

	public float topScore = 2000;

	public States currentState; //current state of controller
	public int currentTurn; //current numerical turn, for use in PlayerOneMove.cs and Player2Move.cs
	MovesLeftController ml;
	private bool countOnce = false;

	public Transform parentP1;
	public Transform parentP2;


	Scene scene;

	void Awake(){
		Debug.Log ("State " + currentState);
		scene = SceneManager.GetActiveScene ();

		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Is Start " + StoreStart.isStart);
		Time.timeScale = 1;

		victorPopup.SetActive (false);

		DecideStart ();
		ml = GetComponent<MovesLeftController>();



	}

	void checkForWinner()
	{
		if (Scores.playerOneTotalScore >= topScore && Scores.playerTwoTotalScore < topScore)
		{
			currentState = States.ENDGAME;
			victor.text = "Player One Wins";
			victorPopup.SetActive (true);
			Time.timeScale = 0;


		}
		if (Scores.playerTwoTotalScore >= topScore && Scores.playerOneTotalScore < topScore)
		{
			currentState = States.ENDGAME;
			victor.text = "Player Two Wins";
			victorPopup.SetActive (true);
			Time.timeScale = 0;

		}

	}


	/*void GoBackToTitle()
	{
		if (currentState == States.ENDGAME)
		{
			Debug.Log ("HIT THIS HERE");
			currentState = States.START;
		}
	}*/
	
	// Update is called once per frame
	void Update () {

        Physics2D.IgnoreLayerCollision(8, 8, true); //Ignore collision between p1 units
        Physics2D.IgnoreLayerCollision(11, 11, true); //Ignore collision between p2 units
        Physics2D.IgnoreLayerCollision(8, 11, true); //Ignore collision between p1 and p2 units


        checkForWinner();
					
		turnText.text = "Player " + currentTurn + "'s Turn";

		switch (currentState) {

		case (States.START):
			break;
		case (States.PLAYERONETURN):
			break;
		case (States.PLAYERTWOTURN):
			break;
		case (States.COMBAT):
			break;
		case (States.RESTORE):
			break;
		case (States.ENDGAME):
			break;


		}

		int checkCycle = 0;

		ResetCountOnce ();

		if (!countOnce)
		{
			if (CycleHolder.cycles != 0 && CycleHolder.cycles % 2 == 0 && checkCycle == 0)
			{
				Debug.Log ("Cycle Achieved");
				getScores ();
				countOnce = true;
			}
		}

		p1ScoreText.text = "Player One  : " + Scores.playerOneTotalScore;
		p2ScoreText.text = "Player Two : " + Scores.playerTwoTotalScore;

			
		PlayerOneTurn ();
		PlayerTwoTurn ();
		AfterCombat ();
	}

	void ResetCountOnce()
	{
		if (CycleHolder.cycles % 2 != 0) 
		{
			countOnce = false;
		}
	}
	void DecideStart()
	{
		if (StoreStart.isStart == true) {
			Debug.Log ("Game Has Started");
			currentState = States.START;

			Debug.Log (scene.name);

			if (scene.name == "BoardScene") 
			{
				currentTurn = decideOrder ();
			} 
			else if (scene.name == "TutorialBoard") 
			{
				Debug.Log ("Got it!!");
				currentTurn = 1;

			}


			//currentTurn = decideOrder ();


			if (currentTurn == 1) {
				currentState = States.PLAYERONETURN;
			} else if (currentTurn == 2) {
				currentState = States.PLAYERTWOTURN;
			}

			StoreStart.isStart = false;
		} else if (StoreStart.isStart == false) 
		{
			currentState = States.RESTORE;
		}

	}

	void PlayerOneTurn()
	{

		if (currentState == States.PLAYERONETURN && Input.GetButtonDown("P1-Start-Button") )
		{
			currentTurn = 2;
			currentState = States.PLAYERTWOTURN;
			MovesLeftController.p1moves = 1;
			CycleHolder.cycles += 1;
			Debug.Log ("Cycle" + CycleHolder.cycles);

		}
	}

	void PlayerTwoTurn()
	{
        if (currentState == States.PLAYERTWOTURN && (scene.name == "BoardScene") && Input.GetButtonDown("P2-Start-Button"))
        {
            currentTurn = 1;
            currentState = States.PLAYERONETURN;
            MovesLeftController.p2moves = 1;
            CycleHolder.cycles += 1;
            Debug.Log(CycleHolder.cycles);

        }
        else if (currentState == States.PLAYERTWOTURN && (scene.name == "TutorialBoard"))
        {
            currentTurn = 1;
            currentState = States.PLAYERONETURN;
            MovesLeftController.p2moves = 1;
            CycleHolder.cycles += 1;
            Debug.Log(CycleHolder.cycles);

        }

    }

	void AfterCombat()
	{
		if (currentState == States.RESTORE)
		{
            checkToKillCaptains();
			resetP1Locations ();
			resetP2Locations ();

			StartCoroutine ("wait");

		}
	}

    void checkToKillCaptains()
    {
        GameObject captain1;
        GameObject captain2;
        captain1 = GameObject.Find("P1Captain");
        captain2 = GameObject.Find("P2Cap");

        if (StoreName.loserName == "P1Captain")
        {
            Destroy(captain1);
        }
        else if(StoreName.loserName == "P2Cap")
        {
            Destroy(captain2);
        }
    }

	void resetP1Locations()
	{
		Vector3 startingPos = new Vector3(-6,-27,0);


		foreach (Transform t in parentP1) 
		{
			if (t.name == StoreName.loserName) {
                Physics2D.IgnoreLayerCollision(8, 8, false); //Ignore collision between p1 units
                t.position = startingPos;
			}
			else if (t.name == "P1Captain") {
				t.position = StoreLocations.P1CaptainPosition;
			}
			else if (t.name == "P1Heavy") {
				t.position = StoreLocations.P1HeavyPosition;
			}
			else if (t.name == "P1Scout3") {
				t.position = StoreLocations.P1Scout1Position;
			}
			else if (t.name == "P1Scout2") {
				t.position = StoreLocations.P1Scout2Position;
			}
		}
	}

	void resetP2Locations()
	{
		Vector3 startingPos = new Vector3(50,2,0);


		foreach (Transform t in parentP2) 
		{
			if (t.name == StoreName.loserName) {
                Physics2D.IgnoreLayerCollision(11, 11, false); //Ignore collision between p2 units
                t.position = startingPos;
			}
			else if (t.name == "P2Cap") {
				t.position = StoreLocations.P2CaptainPosition;
			}
			else if (t.name == "P2Heavy") {
				t.position = StoreLocations.P2HeavyPosition;
			}
			else if (t.name == "P2Scout1") {
				t.position = StoreLocations.P2Scout1Position;
			}
			else if (t.name == "P2Scout2") {
				t.position = StoreLocations.P2Scout2Position;
			}
		}
	}

	void getScores()
	{


			if (StoreActiveBases.p1g1 == true && StoreActiveBases.p2g1 == false) {
				//add to p1's score
				Scores.playerOneTotalScore += 50;
			}

			if (StoreActiveBases.p1g2 == true && StoreActiveBases.p2g2 == false) {
				//add to p1's score
				Scores.playerOneTotalScore += 50;
			}

			if (StoreActiveBases.p1g3 == true && StoreActiveBases.p2g3 == false) {
				//add to p1's score
				Scores.playerOneTotalScore += 50;
			}

			if (StoreActiveBases.p2g1 == true && StoreActiveBases.p1g1 == false) {
				//add to p2's score
				Scores.playerTwoTotalScore += 50;
			}

			if (StoreActiveBases.p2g2 == true && StoreActiveBases.p1g2 == false) {
				//add to p2's score
				Scores.playerTwoTotalScore += 50;
			}

			if (StoreActiveBases.p2g3 == true && StoreActiveBases.p1g3 == false) {
				//add to p2's score
				Scores.playerTwoTotalScore += 50;
			}
	
	}

	int decideOrder() //decide the order at the start of the game
	{
		int rand = Random.Range (1, 3);
		return rand;
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (1f);

		Debug.Log (StoreState.previousState);

		if (StoreState.previousState == States.PLAYERONETURN) {
			currentState = States.PLAYERONETURN;
			currentTurn = 1;
			MovesLeftController.p1moves = 0;

		} else if (StoreState.previousState == States.PLAYERTWOTURN) {
			currentState = States.PLAYERTWOTURN;
			currentTurn = 2;
			MovesLeftController.p2moves = 0;

		}
	}

}
