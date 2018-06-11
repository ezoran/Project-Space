using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class PlayerTwoMove : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	LineRenderer line;


	private static int getTurn; //get who's turn it is from BoardController
	private static int moves; //number of moves left for player
	private bool playerTwoTurn; //check for current player's turn ** currently default to true
	public float totalDistanceAllowed = 10; //total distance unit can travel
	float distance; //distance between target position and current position ** 
	bool clicked; //tell whether the player unit has been clicked on

	public Vector3 targetPosition; 

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		//	ml = GetComponent<MovesLeftController> ();

		line = GetComponent<LineRenderer> ();


		//targetPosition = transform.position;
		Debug.Log(targetPosition);

		targetPosition.z = 0;

	}

	void isTurn() //checks to see if it's player one's turn
	{
		getTurn = BoardController.instance.currentTurn;

		if (getTurn == 2) {
			playerTwoTurn = true;
			//Debug.Log ("It's player ones turn");
		} else if (getTurn == 1) {
			playerTwoTurn = false;
			//Debug.Log ("It's player twos turn");

		}
	}

	bool checkDistance()
	{
		//Calculate distance between two points
		distance = Vector3.Distance (targetPosition, transform.position);

	//	Debug.Log ("Distance: " + distance);

		if (distance <= totalDistanceAllowed) {
			//Debug.Log ("Distance checks out");
			return true;
		}
		else
		{
			return false;
		}


	}

	void DrawLine()
	{
		//Used for drawing the distance check line
		bool getWalk = anim.GetBool("isWalking");

		Vector3 potentialPosition = CustomCursor.cursorPosition;
		potentialPosition.y -= 0.2f;

		potentialPosition.z = 0;
		Debug.Log (potentialPosition);
		Debug.Log (transform.position);

		float getDist = Vector3.Distance (potentialPosition, transform.position); //calculate distance 
		Debug.Log (getDist);

		//the next few lines are used to establish the line
		line.SetWidth (0.1f, 0.1f);
		line.material = new Material(Shader.Find("Particles/Additive"));
		line.SetPosition (0, transform.position);
		line.SetPosition (1, potentialPosition);
		line.sortingOrder = 10;

		if (getWalk == false) {
			line.enabled = true;

			if (getDist <= totalDistanceAllowed) {

				line.SetColors (Color.green, Color.green);
			} else if (getDist >= totalDistanceAllowed) {
				line.SetColors (Color.red, Color.red);

			}
		} 
		else if (getWalk == true) 
		{
			line.enabled = false;

		}



	}

	void Move(){

		if (checkDistance () && clicked == true) {
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, Time.deltaTime * 5);

			Vector3 heading = targetPosition - transform.position;
			float dist = heading.magnitude;
			Vector3 dir = heading / dist;


			if (targetPosition != transform.position) {
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("input_x", dir.x);
				anim.SetFloat ("input_y", dir.y);

			} 
			else {
				anim.SetBool ("isWalking", false);
				targetPosition.Set (0, 0, 0);
				MovesLeftController.p2moves = 0;

			}	


		}

	}


	// Update is called once per frame
	//Handles the actual movement
	void Update () {
		isTurn ();

		if (transform.CompareTag ("P2SelectedUnit") && playerTwoTurn == true && MovesLeftController.p2moves > 0) {

			DrawLine();

			if (Input.GetButtonDown("P2-X-Button")) {
				Debug.Log ("cancel");
				transform.tag = "Player2";
				line.enabled = false;
			}

			if (Input.GetButtonDown("P2-B-Button")) {
				targetPosition = CustomCursor.cursorPosition;	
				targetPosition.z = 0;
				clicked = true;
                PlayerTwoSelectUnit.drawSelectionHand = false;

			}

			Move ();

		} 
		else if (MovesLeftController.p2moves <= 0 || playerTwoTurn == false) 
		{
			transform.tag = "Player2";
			clicked = false;

		}

	}

}
