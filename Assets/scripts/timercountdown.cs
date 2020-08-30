using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timercountdown : MonoBehaviour
{
	public int countdownTime;
	public Text countdownDisplay;

	void Start()
	{
		StartCoroutine(CountdownToStart());
	}

	IEnumerator CountdownToStart()
	{
		while(countdownTime > 0)
		{
			countdownDisplay.text = countdownTime.ToString();

			yield return new WaitForSeconds (1f);
			countdownTime--;
		}
		countdownDisplay.text = "GO!";
		//GameController.instance.BeginGame();

		yield return new WaitForSeconds(1F);

		countdownDisplay.gameObject.SetActive(false);

	}
}