using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDialogue : MonoBehaviour {

	public GameObject dialogue1;
	public GameObject dialogue2;
	public GameObject dialogue3;
	public GameObject dialogue4;
	public GameObject dialogue5;
    public GameObject dialogue6;

	// Use this for initialization
	void Start () {
		
		dialogue1.SetActive (true);
		dialogue2.SetActive (false);
		dialogue3.SetActive (false);
		dialogue4.SetActive (false);
		dialogue5.SetActive (false);
        dialogue6.SetActive (false);

	}

	void DialogueSwitch()
	{
		//Second Dialogue
		if((dialogue1.activeSelf == true) && Input.GetButtonDown("P1-Y-Button"))//button is pressed
		{
			Debug.Log("1");
			dialogue1.SetActive(false);
			Debug.Log(dialogue1.activeSelf);

			dialogue2.SetActive(true);
		}
		else if((dialogue2.activeSelf == true) && (dialogue1.activeSelf == false) && Input.GetButtonDown("P1-Y-Button"))//button is pressed
		{
			Debug.Log("2");
			dialogue2.SetActive(false);
			dialogue3.SetActive(true);
		}
		//Fourth dialogue
		else if((dialogue3.activeSelf == true) && (StoreActiveBases.p1g1 == true))//Player reaches base
		{
			Debug.Log("3");
			dialogue3.SetActive(false);

			dialogue4.SetActive(true);
		}
		//Fifth dialogue
		else if((dialogue4.activeSelf == true) && Input.GetButtonDown("P1-Y-Button"))//Player reaches base
		{
			Debug.Log("4");
			dialogue4.SetActive(false);

			dialogue5.SetActive(true);
		}
        else if ((dialogue5.activeSelf == true) && (StoreActiveBases.p1g3 == true))//Player reaches base
        {
            Debug.Log("5");
            dialogue5.SetActive(false);

            dialogue6.SetActive(true);
        }


    }


	// Update is called once per frame
	void Update () {
		DialogueSwitch ();
	}
}
