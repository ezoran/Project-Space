using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUnitStats : MonoBehaviour {

	public static float p1Health;
	public static float p2Health;

	public static float p1ROF;
	public static float p2ROF;

	public static int p1Damage;
	public static int p2Damage;

	public static string p1Anim;
	public static string p2Anim;

	void SetP1Stats(string name)
	{
		if (name == "P1Scout3" )
		{
			p1Health = 100;
			p1ROF = 5;
			p1Damage = 10;
			p1Anim = "scout1p1anim";
		}
		else if (name == "P1Scout2") 
		{
			p1Health = 100;
			p1ROF = 5;
			p1Damage = 10;
			p1Anim = "scout2p1anim";

		}
		else if (name == "P1Heavy")
		{
			p1Health = 300;
			p1ROF = 7;
			p1Damage = 20;
			p1Anim = "heavyp1anim";

		}
		else if (name == "P1Captain")
		{
			p1Health = 500;
			p1ROF = 10;
			p1Damage = 40;
			p1Anim = "captainp1anim";

		}
	}

	void SetP2Stats(string name)
	{
		if (name == "P2Scout1")
		{
			p2Health = 100;
			p2ROF = 5;
			p2Damage = 10;
			p2Anim = "scout1p2anim";

		}
		else if (name == "P2Scout2") 
		{
			p2Health = 100;
			p2ROF = 5;
			p2Damage = 10;
			p2Anim = "scout2p2anim";

		}
		else if (name == "P2Heavy")
		{
			p2Health = 300;
			p2ROF = 7;
			p2Damage = 20;
			p2Anim = "heavyp2anim";

		}
		else if (name == "P2Cap")
		{
			p2Health = 500;
			p2ROF = 10;
			p2Damage = 40;
			p2Anim = "captainp2anim";

		}
	}
	// Use this for initialization
	void Start () {
		string p1currentUnit = StoreName.player1inCombat;
		string p2currentUnit = StoreName.player2inCombat;

		//SetP1Stats ("P1Captain");
    	//SetP2Stats ("P2Heavy");

		SetP1Stats (p1currentUnit);
		SetP2Stats (p2currentUnit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
