using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour {

	public Text countdownText;

	bool triggerCountdown;
	public static bool canBegin;
    bool initiateCountdown;

	public Camera primaryCamera;
	public Camera secondaryCamera;

	public Transform playerOne;
	public Transform playerTwo;

	float timeLeft = 3;

	// Use this for initialization
	void Awake () {
		primaryCamera.enabled = true;
		secondaryCamera.enabled = false;
		canBegin = false;
        initiateCountdown = false;
		countdownText.gameObject.SetActive (false);

		setScene ();

	}

	void setScene()
	{
		StartCoroutine ("wait");
	}

	void moveCameraP1()
	{
		Vector3 moveP1V = playerOne.transform.position;
		moveP1V.z = -10;
		secondaryCamera.transform.position = moveP1V;
	}
		
	void moveCameraP2()
	{
		Vector3 moveP2V = playerTwo.transform.position;
		moveP2V.z = -10;
		secondaryCamera.transform.position = moveP2V;

	}
	

	IEnumerator wait()
	{
		yield return new WaitForSeconds (2f);

		primaryCamera.enabled = false;
		secondaryCamera.enabled = true;


		moveCameraP2();
		yield return new WaitForSeconds (2f);

		moveCameraP1 ();
		yield return new WaitForSeconds (2f);


		primaryCamera.enabled = true;
		secondaryCamera.enabled = false;
		initiateCountdown = true;
		countdownText.gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (initiateCountdown) 
		{
			timeLeft -= Time.deltaTime;
			countdownText.text = "" + Mathf.Round (timeLeft);

			if (timeLeft <= 0) 
			{
				countdownText.gameObject.SetActive (false);
                canBegin = true;
			}
		}

	}

}
