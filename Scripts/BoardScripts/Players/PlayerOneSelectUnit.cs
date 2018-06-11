using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerOneSelectUnit : MonoBehaviour {
	public bool selected = false;
	public Vector3 location = new Vector3(0,0,0);
	private static int getTurn; //get who's turn it is from BoardController
	private bool playerOneTurn; //check for current player's turn ** currently default to true

    public static bool drawSelectionHand;

    // Use this for initialization
    void Start () {
        drawSelectionHand = false;
    }

    void isTurn() //checks to see if it's player one's turn
	{
		getTurn = BoardController.instance.currentTurn;

		if (getTurn == 1) {
			playerOneTurn = true;
			//Debug.Log ("It's player ones turn");
		} else if (getTurn == 2) {
			playerOneTurn = false;
			//Debug.Log ("It's player twos turn");

		}
	}



	// Update is called once per frame
	void Update () {

		RaycastHit2D hit = Physics2D.Raycast(CustomCursor.cursorPosition, Vector2.zero);

		isTurn();

		if ((hit.collider != null) && Input.GetButtonDown("P1-A-Button") && getTurn == 1) {
			Debug.Log (hit.collider.name);
			if ((hit.collider.tag == "Player1")) 
			{
				Debug.Log(hit.collider.name + ", " + hit.collider.tag);

				location = hit.collider.gameObject.transform.position;
				Debug.Log ("Target Position: " + location);


				hit.collider.gameObject.transform.tag = "P1SelectedUnit";
				selected = true;
                drawSelectionHand = true;
			}

		}
		else if (hit.collider == null && Input.GetButtonDown("P1-A-Button")) {
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

