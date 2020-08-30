using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
public class MainMenu : MonoBehaviour
{
	
	public SceneFader fader;
	public string LevelName;

//	public GameObject Scorestartmenu;
	public Transform Highscoretabel;
//
	public string LevelNameSelect;
	public string LevelNSelect;
//	private Transform entryContainer;
//	public Transform entryTemplate;
	//public GameObject HighscoretableOn;
	public GameObject TextInputname; //set name menu 
	//	public TMP_InputField inputText; // set name menu field
	//	public string tutorialText ;


	public void getlevelName ()

	{
		

		LevelName = EventSystem.current.currentSelectedGameObject.name;
		LevelNSelect = EventSystem.current.currentSelectedGameObject.name;
		Highscoretabel.gameObject.SetActive(true);
		//TextInputname.gameObject.SetActive(true);

		//print (LevelName);//-------
//		Scene currentScene = SceneManager.LoadScene(LevelName.name);
//		//Scene currentScene = SceneManager.GetActiveScene();
//		print(currentScene.name);
//
		LevelNameSelect = LevelNSelect.ToString();
		//print(LevelNameSelect);
		//entryContainer = transform.Find("highscoreEntryContainer");

	}





	public void Select () //hiermee moet je naar het level
	{
		SceneManager.LoadScene(LevelName);
	
	
	}

	public void levelselectterug ()
	{
		Highscoretabel.gameObject.SetActive(false);
		//TextInputname.gameObject.SetActive(true);

	}

	public void QuiteGame ()
	{
		
		Debug.Log ("quit");
		Application.Quit();
	}

}
