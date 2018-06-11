using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StoreStart.isStart = true;

		Scores.playerTwoTotalScore = 0;
		Scores.playerTwoTotalScore = 0;
		CycleHolder.cycles = 0;
	}
	
	// Update is called once pe frame
	void Update () {
		
	}
}
