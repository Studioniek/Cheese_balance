using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour


{
    
	//public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		//if (Input.GetKeyDown(KeyCode.B))
	//	{
	//		if (GameIsPaused)
	//		{
	//			Resume();
	//		} else
	//			Pause();
	//		}
	//
	//	}
    }

	void Pause ()
	{
		//pauseMenuUI.SetActive (true);
		//Time.timeScale = 0f;
		//GameIsPaused = true;
	}



	void Resume ()
	{
	//	pauseMenuUI.SetActive (false);
	//	Time.timeScale = 1f;
	//	GameIsPaused = false;
	}

	public void Options ()
	{
		
	}

	public void Exit ()
	{
		Debug.Log ("quit");
		Application.Quit();
	}



}
