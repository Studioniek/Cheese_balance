using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class savingname : MonoBehaviour
{
    // Start is called before the first frame update
	public  TMP_InputField inputText;
	string tutorialText;
	public GameObject TextInputname;
	public GameObject TextInputnamebuttonsave;
	void Start()
	{

		tutorialText = PlayerPrefs.GetString ("tutorialTextKeyName");
		inputText.text = tutorialText;
		//print (inputText.text);
	
	}

	public void backtomenu()
	{
		
		TextInputname.gameObject.SetActive(false);
		TextInputnamebuttonsave.gameObject.SetActive(true);
		//PlayerPrefs.DeleteAll();
	}
	public void tolevelselect()
	{

		TextInputname.gameObject.SetActive(true);
		//PlayerPrefs.DeleteAll();
	}







	public void SaveThis()
	{
		tutorialText = inputText.text;
		PlayerPrefs.SetString (("CurrentPlayerName"), tutorialText);
		print (tutorialText);
		TextInputnamebuttonsave.gameObject.SetActive(false);
		//PlayerPrefs.DeleteAll();
	}
}