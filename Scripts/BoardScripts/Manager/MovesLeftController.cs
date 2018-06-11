using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesLeftController : MonoBehaviour 
{

	public static int p1moves; //number of moves for any given turn
	public static int p2moves;

	public Text text;

	// Use this for initialization
	void Start () {
		p1moves = 1;
		p2moves = 1;
	}

	void Update () {
		if (BoardController.instance.currentState == States.PLAYERONETURN)
		{
			text.text = "Moves Left: " + p1moves;
		}
		if (BoardController.instance.currentState == States.PLAYERTWOTURN)
		{
			text.text = "Moves Left: " + p2moves;
		}
		//Debug.Log("P1 Moves: " + p1moves);
		//Debug.Log("P2 Moves: " + p2moves);

	}


}
