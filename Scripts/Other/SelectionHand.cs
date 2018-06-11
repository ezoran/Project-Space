using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHand : MonoBehaviour {

    public GameObject P1hand;
    public GameObject P2hand;

	// Use this for initialization
	void Start () {
        P1hand.SetActive(false);
        P2hand.SetActive(false);

    }


    // Update is called once per frame
    void Update () {

        Debug.Log("Is hand active? " + P1hand.activeSelf);
        Debug.Log("Hand Location: " + P1hand.transform.position);

        if (PlayerOneSelectUnit.drawSelectionHand)
        {
             GameObject currentUnit = GameObject.FindGameObjectWithTag("P1SelectedUnit");
             P1hand.transform.position = currentUnit.transform.position;
             P1hand.transform.position = new Vector3(P1hand.transform.position.x, P1hand.transform.position.y + 1, P1hand.transform.position.z);
             P1hand.SetActive(true);
        }
        else if(!PlayerOneSelectUnit.drawSelectionHand)
        {
            P1hand.SetActive(false);
        }

        if (PlayerTwoSelectUnit.drawSelectionHand)
        {
            GameObject currentUnit = GameObject.FindGameObjectWithTag("P2SelectedUnit");
            P2hand.transform.position = currentUnit.transform.position;
            P2hand.transform.position = new Vector3(P2hand.transform.position.x, P2hand.transform.position.y + 1, P2hand.transform.position.z);
            P2hand.SetActive(true);

        }
        else if (!PlayerTwoSelectUnit.drawSelectionHand)
        {
            P2hand.SetActive(false);
        }
    }
}
