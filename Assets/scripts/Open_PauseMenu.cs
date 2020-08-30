using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open_PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
	public static bool ActiveMenu = false;
	public GameObject PauseMenu1;

	//public float timeStart;
	//public Text textBox;
	//public Text startBtnText;

	//bool timerActive = False;


	void Start()
	{

		ActiveMenu = false;
		PauseMenu1.SetActive (false);
	}
		void Update()
	{
		//ActiveMenu = false;
		//PauseMenu1.SetActive (false);
	}

		//public GameObject ActiveMenu;
	public void OpenPauseMenu()
	{//if (PauseMenu1 != null)
		{
			if (ActiveMenu)
			{
				Time.timeScale = 1;
				ActiveMenu = false;
				PauseMenu1.SetActive (false);
			}
			else
			{
				bool isActive = PauseMenu1.activeSelf;
				Time.timeScale = 0;
				ActiveMenu = true;
				PauseMenu1.SetActive (true);
			}
		}
	}

	public void StartMenu ()
	{
		SceneManager.LoadScene(0);
	}

	public void Restart ()
	{

		Time.timeScale = 1;
		ActiveMenu = false;
		PauseMenu1.SetActive (false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


}

