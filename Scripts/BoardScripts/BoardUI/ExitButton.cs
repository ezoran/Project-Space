using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

	public void leave()
	{
		Time.timeScale = 1;
		Scores.playerOneTotalScore = 0;
		Scores.playerTwoTotalScore = 0;
		SceneManager.LoadScene (0);
	}
}
