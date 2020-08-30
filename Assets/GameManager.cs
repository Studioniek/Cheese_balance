//using System.Collections;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;
//using System;
//using static ScoreManager;
//
//public class GameManager : MonoBehaviour {
//	public static GameManager instance;
//
//	public GameObject Col_end_Negative;
//	public GameObject Col_end_Positive;
//	public GameObject Bal;
//	public GameObject GameObjectKnife;
//
//	public bool gamePlaying { get; private set; }
//	public int countdownTime; //teller van aftellen
//	//public Text countdownDisplay;
//	public TextMeshPro countdownDisplay; //teller van aftellen
//	private float startTime, elapsedTime;
//	TimeSpan timePlaying;
//	public TextMeshPro LevelCount;
//	bool gameHasEnded = false;
//	public float restartDelay = 1f;
//	public float ToMenuDelay = 3f;
//	public static bool ActiveMenu = false;
//	public static bool ActiveOptionsMenu = false;
//	public GameObject PauseMenu1;
//	public GameObject OptionsMenu1;
//	public GameObject NextLevelbutton;
//	public GameObject Highscoretab;
//
//	public TextMeshPro BestText;
//	public TextMeshPro WorstText;
//	public GameObject EndGameButton;
//	public GameObject EndGameObject;
//	public TextMeshPro timeCounter; //dit is je score
//	public ScoreManager GetscoresScript;
//	public GameObject HighscoretableOn;
//	//string PrefsbrakeUp;
//	void Start() {
//		//PlayerPrefs.DeleteAll();
//		Highscores.Load();
//		//Debug.Log(Highscores.Load());
//		HighscoretableOn.SetActive(false);
//		//		string name = SceneManager.GetActiveScene().name;
//		//
//		//		Debug.Log("Loading "+name);
//		//		name += "Highscore";
//		BestText.text = Highscores.Get(0).time.ToString("00:00:000");
//		//	
//		WorstText.text = Highscores.Get(2).time.ToString("00:00:000");
//		timeCounter.text = ("00:00:000");
//		GameObject.Find("GameObject").GetComponent<Controll_objects_Right_Left>().enabled = false;
//
//		LevelCount.text = "LEVEL:" + SceneManager.GetActiveScene().buildIndex.ToString();//buildIndex.ToString();
//		gamePlaying = false;
//		BeginGame();
//		StartCoroutine(CountdownToStart());
//		ActiveMenu = false;
//		ActiveOptionsMenu = false;
//		PauseMenu1.SetActive(false);
//		OptionsMenu1.SetActive(false);
//		NextLevelbutton.SetActive(false);
//		EndGameButton.SetActive(false);
//		EndGameObject.SetActive(false);
//		Time.timeScale = 1;
//
//		Scene currentScene = SceneManager.GetActiveScene();
//		string sceneName = currentScene.name;
//
//		//print (currentScen)
//		if (sceneName == "LVL_002") //of het laatst levelnr
//		{
//			EndGameObject.SetActive(true);
//		}
//
//		if (sceneName == "LVL_008") //of het laatst levelnr
//		{
//
//			PlayerPrefs.DeleteKey("HighScore1" + SceneManager.GetActiveScene());
//			PlayerPrefs.DeleteKey("HighScore2" + SceneManager.GetActiveScene());
//			PlayerPrefs.DeleteKey("HighScore3" + SceneManager.GetActiveScene());
//			PlayerPrefs.DeleteKey("HighScore1");
//		}
//
//	}
//
//	IEnumerator CountdownToStart() {
//		while (countdownTime > 0) {
//			countdownDisplay.text = countdownTime.ToString();
//			yield return new WaitForSeconds(0.5f);
//			countdownTime--;
//		}
//		countdownDisplay.text = "GO!";
//		yield return new WaitForSeconds(0.5F);
//		countdownDisplay.gameObject.SetActive(false);
//		gamePlaying = true;
//		startTime = Time.time;
//		GameObject.Find("GameObject").GetComponent<Controll_objects_Right_Left>().enabled = true;
//	}
//
//	private void BeginGame() {
//
//	}
//	// Update is called once per frame
//	void Update() {
//		if (gamePlaying == true) {
//			elapsedTime = Time.time - startTime;
//			timePlaying = TimeSpan.FromSeconds(elapsedTime);
//			string TimePlayingStr = timePlaying.ToString("mm':'ss':'fff");
//			timeCounter.text = TimePlayingStr;
//		}
//	}
//
//	public void OpenPauseMenu() {//if (PauseMenu1 != null)
//		{
//			if (ActiveMenu) {
//				Time.timeScale = 1;
//				ActiveMenu = false;
//				PauseMenu1.SetActive(false);
//			}
//			else {
//				bool isActive = PauseMenu1.activeSelf;
//				Time.timeScale = 0;
//				ActiveMenu = true;
//				PauseMenu1.SetActive(true);
//			}
//		}
//	}
//	public void OpenOptionsMenu() {
//		if (ActiveOptionsMenu) {
//			ActiveOptionsMenu = false;
//			OptionsMenu1.SetActive(false);
//		}
//		else {
//			bool isActive = PauseMenu1.activeSelf;
//			ActiveOptionsMenu = true;
//			OptionsMenu1.SetActive(true);
//		}
//	}
//	public void StartMenu() {
//		SceneManager.LoadScene(0);
//	}
//	public void Restart() {
//		Time.timeScale = 1;
//		ActiveMenu = false;
//		PauseMenu1.SetActive(false);
//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//		//PlayerPrefs.DeleteKey("HighScore");
//	}
//	public void Respawn() {
//		if (gameHasEnded == false) {
//			Debug.Log("gameoverrespawn");
//			gameHasEnded = true;
//			Invoke("Restart", restartDelay);
//		}
//	}
//	public void Finish() {
//		string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName", "???"); // To get the player name, it should be set in "Level 0"
//
//		Highscoretab.SetActive(true);
//
//		gameHasEnded = true;
//		PauseMenu1.SetActive(true);
//		NextLevelbutton.SetActive(true);
//		gamePlaying = false;
//
//		print(BestText.text);
//		String TimeBestemaak = BestText.text;
//		String TimeBestemaakcut1 = TimeBestemaak.Remove(2, 1);
//		String TimeBestemaakcut2 = TimeBestemaakcut1.Remove(4, 1);
//		String TimeBestemaaknummer = TimeBestemaakcut2;
//		int TimeBestemaakvast = int.Parse(TimeBestemaaknummer);
//		int TimeBestNumber = TimeBestemaakvast;
//		print(TimeBestNumber);
//
//		print(timeCounter.text);
//		String Timecountermaak = timeCounter.text;
//		String Timecountermaakcut1 = Timecountermaak.Remove(2, 1);
//		String Timecountermaakcut2 = Timecountermaakcut1.Remove(4, 1);
//		String Timecountermaaknummer = Timecountermaakcut2;
//		int Timecountermaakvast = int.Parse(Timecountermaaknummer);
//		int TimecountNumber = Timecountermaakvast;
//		print(TimecountNumber);
//
//		print(WorstText.text);
//		String TimeWorstmaak = WorstText.text;
//		String TimeWorstmaakcut1 = TimeWorstmaak.Remove(2, 1);
//		String TimeWorstmaakcut2 = TimeWorstmaakcut1.Remove(4, 1);
//		String TimeWorstmaaknummer = TimeWorstmaakcut2;
//		int TimeWorstmaakvast = int.Parse(TimeWorstmaaknummer);
//		int TimeWorstNumber = TimeWorstmaakvast;
//		print(TimeWorstNumber);
//
//		// Update the HighScore
//		GetscoresScript.AddHighscoreEntry(TimecountNumber, currentPlayerName);
//	}
//
//
//
//	public void EndGame() {
//
//		if (gameHasEnded == false)
//			gameHasEnded = true;
//
//		//EndMenu.SetActive (true);
//		PauseMenu1.SetActive(true);
//		EndGameButton.SetActive(true);
//		gamePlaying = false;
//
//	}
//	public void NextLevel() {
//		//if (gameHasEnded == false)
//		if (NextLevelbutton == true) {
//			gameHasEnded = false;
//
//
//
//			//Text_Score.text
//			Nextlevel();
//			//Invoke("Nextlevel", ToMenuDelay);
//		}
//	}
//	public void EindeLevels() {
//		//if (gameHasEnded == false)
//		if (EndGameButton == true) {
//
//			Debug.Log("gameovertoMenu");
//			gameHasEnded = false;
//			//	string TimePlayingStr = "TIME:" + timePlaying.ToString("mm':'ss'.'fff");
//
//			Tostartmenu();
//			//Nextlevel ();
//			//Invoke("Nextlevel", ToMenuDelay);
//		}
//	}
//
//
//
//
//	void Restartlevel() {
//		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//
//	}
//	void Nextlevel() {
//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//	}
//	void Tostartmenu() {    //public void EndGame()
//		SceneManager.LoadScene(0);
//		//SceneManager.LoadScene(SceneManager.GetActiveScene().Menu_cheese_game);
//		//SceneManager.LoadScene("Menu_cheese_game");
//	}
//
//}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using static ScoreManager;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public GameObject Col_end_Negative;
	public GameObject Col_end_Positive;
	public GameObject Bal;
	public GameObject GameObjectKnife;

	public bool gamePlaying { get; private set; }
	public int countdownTime; //teller van aftellen
	//public Text countdownDisplay;
	public TextMeshPro countdownDisplay; //teller van aftellen
	private float startTime, elapsedTime;
	TimeSpan timePlaying;
	public TextMeshPro LevelCount;
	bool gameHasEnded = false;
	public float restartDelay = 1f;
	public float ToMenuDelay = 3f;
	public static bool ActiveMenu = false;
	public static bool ActiveOptionsMenu = false;
	public GameObject PauseMenu1;
	public GameObject OptionsMenu1;
	public GameObject NextLevelbutton;
	public GameObject Highscoretab;

	public TextMeshPro BestText;
	public TextMeshPro WorstText;
	public GameObject EndGameButton;
	public GameObject EndGameObject;
	public TextMeshPro timeCounter; //dit is je score
	public ScoreManager GetscoresScript;
	public GameObject HighscoretableOn;
	public savingname SavePlayername;

	public GameObject turnoff;
	//string PrefsbrakeUp;
	void Start() {

		//PlayerPrefs.DeleteAll();


		Highscores.Load();
		string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName");

		//Debug.Log(Highscores.Load());
		HighscoretableOn.SetActive(false);
		//		string name = SceneManager.GetActiveScene().name;
		//
		//		Debug.Log("Loading "+name);
		//		name += "Highscore";
		BestText.text = Highscores.Get(0).time.ToString("00:00:000");
		//	
		WorstText.text = Highscores.Get(2).time.ToString("00:00:000");
		timeCounter.text = ("00:00:000");
		GameObject.Find("GameObject").GetComponent<Controll_objects_Right_Left>().enabled = false;

		LevelCount.text = "LEVEL:" + SceneManager.GetActiveScene().buildIndex.ToString();//buildIndex.ToString();
		gamePlaying = false;
		BeginGame();
		StartCoroutine(CountdownToStart());
		ActiveMenu = false;
		ActiveOptionsMenu = false;
		PauseMenu1.SetActive(false);
		OptionsMenu1.SetActive(false);
		NextLevelbutton.SetActive(false);
		EndGameButton.SetActive(false);
		//EndGameObject.SetActive(false);
		Time.timeScale = 1;

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		//print (currentScen)
		if (sceneName == "LVL_006") //of het laatst levelnr
		{
			EndGameObject.SetActive(true);
		}

//		if (sceneName == "LVL_008") //of het laatst levelnr
//		{
//
//			PlayerPrefs.DeleteKey("HighScore1" + SceneManager.GetActiveScene());
//			PlayerPrefs.DeleteKey("HighScore2" + SceneManager.GetActiveScene());
//			PlayerPrefs.DeleteKey("HighScore3" + SceneManager.GetActiveScene());
//			PlayerPrefs.DeleteKey("HighScore1");
//		}

	}

	IEnumerator CountdownToStart() {
		while (countdownTime > 0) {
			countdownDisplay.text = countdownTime.ToString();
			yield return new WaitForSeconds(0.5f);
			countdownTime--;
		}
		countdownDisplay.text = "GO!";
		yield return new WaitForSeconds(0.5F);
		countdownDisplay.gameObject.SetActive(false);
		gamePlaying = true;
		startTime = Time.time;
		GameObject.Find("GameObject").GetComponent<Controll_objects_Right_Left>().enabled = true;
		GameObject.Find("balletje").GetComponent<Rigidbody>().useGravity = true;
	
	}

	private void BeginGame() {

	}
	// Update is called once per frame
	void Update() {
		if (gamePlaying == true) {
			elapsedTime = Time.time - startTime;
			timePlaying = TimeSpan.FromSeconds(elapsedTime);
			string TimePlayingStr = timePlaying.ToString("mm':'ss':'fff");
			timeCounter.text = TimePlayingStr;
		}
	}

	public void OpenPauseMenu() {//if (PauseMenu1 != null)
		{
			if (ActiveMenu) {
				Time.timeScale = 1;
				ActiveMenu = false;
				PauseMenu1.SetActive(false);
			}
			else {
				bool isActive = PauseMenu1.activeSelf;
				Time.timeScale = 0;
				ActiveMenu = true;
				PauseMenu1.SetActive(true);
			}
		}
	}
	public void OpenOptionsMenu() {
		if (ActiveOptionsMenu) {
			ActiveOptionsMenu = false;
			OptionsMenu1.SetActive(false);
		}
		else {
			bool isActive = PauseMenu1.activeSelf;
			ActiveOptionsMenu = true;
			OptionsMenu1.SetActive(true);
		}
	}
	public void StartMenu() {
		SceneManager.LoadScene(0);
	}
	public void Restart() {
		Time.timeScale = 1;
		ActiveMenu = false;
		PauseMenu1.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//PlayerPrefs.DeleteKey("HighScore");
	}
	public void Respawn() {
		if (gameHasEnded == false) {
			//Debug.Log("gameoverrespawn");
			gameHasEnded = true;
			Invoke("Restart", restartDelay);
		}
	}
	//	public void SetNameScore()
	//
	//	TextInputname.gameObject.SetActive(true);

	public void Finish() {


		turnoff.gameObject.SetActive(false);

		//string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName");

		Highscoretab.SetActive(true);
	

		gameHasEnded = true;
		PauseMenu1.SetActive(true);
		NextLevelbutton.SetActive(true);
		gamePlaying = false;

		print(BestText.text);
		String TimeBestemaak = BestText.text;
		String TimeBestemaakcut1 = TimeBestemaak.Remove(2, 1);
		String TimeBestemaakcut2 = TimeBestemaakcut1.Remove(4, 1);
		String TimeBestemaaknummer = TimeBestemaakcut2;
		int TimeBestemaakvast = int.Parse(TimeBestemaaknummer);
		int TimeBestNumber = TimeBestemaakvast;
		print(TimeBestNumber);

		print(timeCounter.text);
		String Timecountermaak = timeCounter.text;
		String Timecountermaakcut1 = Timecountermaak.Remove(2, 1);
		String Timecountermaakcut2 = Timecountermaakcut1.Remove(4, 1);
		String Timecountermaaknummer = Timecountermaakcut2;
		int Timecountermaakvast = int.Parse(Timecountermaaknummer);
		int TimecountNumber = Timecountermaakvast;
		print(TimecountNumber);

		print(WorstText.text);
		String TimeWorstmaak = WorstText.text;
		String TimeWorstmaakcut1 = TimeWorstmaak.Remove(2, 1);
		String TimeWorstmaakcut2 = TimeWorstmaakcut1.Remove(4, 1);
		String TimeWorstmaaknummer = TimeWorstmaakcut2;
		int TimeWorstmaakvast = int.Parse(TimeWorstmaaknummer);
		int TimeWorstNumber = TimeWorstmaakvast;
		print(TimeWorstNumber);

//		if (TimeWorstNumber > TimecountNumber) // als derde plaats beter is als de gezette tijd.
//					{
//						TextInputname.gameObject.SetActive(true);
//			
//						Highscoretab.SetActive(false);
//					}


		// Update the HighScore
		string currentPlayerName = PlayerPrefs.GetString("CurrentPlayerName");
		GetscoresScript.AddHighscoreEntry(TimecountNumber, currentPlayerName);
	
	
	}



	public void EndGame() {

		if (gameHasEnded == false)
			gameHasEnded = true;

		//EndMenu.SetActive (true);
		PauseMenu1.SetActive(true);
		EndGameButton.SetActive(true);
		gamePlaying = false;

	}
	public void NextLevel() {
		//if (gameHasEnded == false)
		if (NextLevelbutton == true) {
			gameHasEnded = false;



			//Text_Score.text
			Nextlevel();
			//Invoke("Nextlevel", ToMenuDelay);
		}
	}
	public void EindeLevels() {
		//if (gameHasEnded == false)
		if (EndGameButton == true) {

			Debug.Log("gameovertoMenu");
			gameHasEnded = false;
			//	string TimePlayingStr = "TIME:" + timePlaying.ToString("mm':'ss'.'fff");

			Tostartmenu();
			//Nextlevel ();
			//Invoke("Nextlevel", ToMenuDelay);
		}
	}




	void Restartlevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}
	void Nextlevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	void Tostartmenu() {    //public void EndGame()
		SceneManager.LoadScene(0);
		//SceneManager.LoadScene(SceneManager.GetActiveScene().Menu_cheese_game);
		//SceneManager.LoadScene("Menu_cheese_game");
	}

}
