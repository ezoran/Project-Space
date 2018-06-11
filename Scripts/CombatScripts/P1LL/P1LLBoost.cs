using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class P1LLBoost : MonoBehaviour {

	public GameObject parent;
	public GameObject p1LLBurst;
	public Text displayText;

	GameObject p1;
	GameObject p2;



	public p1Health p1health;
	public p2Health p2health;

	public static float bonus;
	public float healthIncrease = 10;
	public int damageIncrease = 10;
	public float speedIncrease = 10;

	void Start()
	{
		p1 = GameObject.Find ("Player1");
		p2 = GameObject.Find ("Player2");


		displayText = GameObject.Find ("P1LLtext").GetComponent<Text> ();;
	}

	void Update()
	{
		p1health = p1.GetComponent<p1Health> ();
		p2health = p2.GetComponent<p2Health> ();
	}
	string RandomBenefit()
	{
		string[] types = { "Health", "Damage"};

		int rand = UnityEngine.Random.Range (0, 2);
	
		string choice = (string)types.GetValue (rand);
		return choice;
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		string choice = RandomBenefit ();
		Debug.Log (choice);


		if (other.tag == "Player1" || other.tag == "Player2") 
		{
			if (other.tag == "Player1" && String.Compare (choice, "Health", false) == 0 ) 
			{
				displayText.text = "Player One Granted Health";

				p1health.currentHealth += healthIncrease;
			}

			else if(other.tag == "Player2" && String.Compare (choice, "Health", false) == 0 )
			{
				displayText.text = "Player Two Granted Health";

				p2health.currentHealth += healthIncrease;
						
			}	
			if (other.tag == "Player1" && String.Compare (choice, "Damage", false) == 0 ) 
			{
				displayText.text = "Player One Granted Damage";

				Debug.Log (GetUnitStats.p1Damage);
				GetUnitStats.p1Damage += damageIncrease;
				Debug.Log (GetUnitStats.p1Damage);
			}
			else if(other.tag == "Player2" && String.Compare (choice, "Damage", false) == 0 )
			{
				displayText.text = "Player Two Granted Damage";
				Debug.Log (GetUnitStats.p2Damage);
				GetUnitStats.p2Damage += damageIncrease;
				Debug.Log (GetUnitStats.p2Damage);
			}	
		

			//Play animation
			bool readyToDie = false;
		
			if (readyToDie == false)
			{
				Instantiate (p1LLBurst, transform.position, transform.rotation);
				readyToDie = true;
			}
			if (readyToDie == true)
			{
			//	Destroy (this.gameObject);
				Destroy (parent);
			}

		}

	}


}
