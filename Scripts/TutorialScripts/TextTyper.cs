using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour {


	public float letterPause = 0.2f;
	public string fullText;
	private string currentText = "";

	void Start()
	{
		StartCoroutine (ShowText ());
	}

	IEnumerator ShowText()
	{
		for(int i = 0; i < fullText.Length; i++)
		{
			currentText = fullText.Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			yield return new WaitForSeconds (letterPause);
		}
	}
}
