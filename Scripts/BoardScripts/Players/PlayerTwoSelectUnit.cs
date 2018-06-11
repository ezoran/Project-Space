using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoSelectUnit : MonoBehaviour {
	public bool selected = false;
	public Vector3 location = new Vector3(0,0,0);
	private static int getTurn; //get who's turn it is from BoardController
	private bool playerTwoTurn; //check for current player's turn ** currently default to true

    public static bool drawSelectionHand;


	// Use this for initialization
	void Start () {
        drawSelectionHand = false;
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

	// Update is called once per frame
	void Update () {


		RaycastHit2D hit = Physics2D.Raycast(CustomCursor.cursorPosition, Vector2.zero);

		isTurn();

		if ((hit.collider != null) && Input.GetButtonDown("P2-A-Button") && getTurn == 2) {
			if ((hit.collider.tag == "Player2")) 
			{
				Debug.Log(hit.collider.name + ", " + hit.collider.tag);

				location = hit.collider.gameObject.transform.position;
				Debug.Log ("Target Position: " + location);


				hit.collider.gameObject.transform.tag = "P2SelectedUnit";
				selected = true;
                drawSelectionHand = true;
			}

		}
		else if (hit.collider == null && Input.GetButtonDown("P2-A-Button") ) {
			Debug.Log ("NO HIT");
			removeObject ();
		}
	}

	void removeObject()
	{
		var items = GameObject.FindGameObjectsWithTag("Tool");
		foreach (var item in items)
		{
			Destroy(item);
		}
	}
}
