using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class ScoreManagerMainmenu : MonoBehaviour {
	//public script ScriptGameManager;

	public string LevelNameSelect;
	public string LevelNSelect;
	private Transform entryContainer;
	public Transform entryTemplate;
	public GameObject HighscoretableOn;

	private List<Transform> highscoreEntryTransformList;



	public void Awake() {


		Scene currentScene = SceneManager.GetActiveScene();

		print(currentScene.name);
		LevelNameSelect = LevelNSelect.ToString();
		print(LevelNameSelect);
		entryContainer = transform.Find("highscoreEntryContainer");

		entryTemplate.gameObject.SetActive(false);

		if (Highscores.Get(0).time == 0) {
			// There's no stored table, initialize
			Debug.Log("Initializing table with default values...");
			AddHighscoreEntry(2005001, "Nik");
			AddHighscoreEntry(1010002, "CPU");
			AddHighscoreEntry(0040003, "CP2");
		}

		highscoreEntryTransformList = new List<Transform>();
		for (int i = 0; i < Highscores.Count; i++) {
			HighscoreEntry highscoreEntry = Highscores.Get(i);
			CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
		}
	}

	private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
		Transform entryTransform = Instantiate(entryTemplate, container);
		entryTransform.gameObject.SetActive(true);
		entryTransform.localScale = new Vector3(8, 8, 1);

		int rank = transformList.Count + 1;
		string rankString;
		switch (rank) {
		default:
			rankString = rank + "TH"; break;

		case 1: rankString = "1ST"; break;
		case 2: rankString = "2ND"; break;
		case 3: rankString = "3RD"; break;
		}

		entryTransform.Find("PosText").GetComponent<TextMeshProUGUI>().text = rankString;
		int time = highscoreEntry.time;
		entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().text = time.ToString("00:00:000");
		string name = highscoreEntry.name;
		entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
		transformList.Add(entryTransform);
	}

	public void AddHighscoreEntry(int time, string name) {
		Highscores.Add(time, name);
		//Highscores.Save();

		foreach (Transform t in entryContainer.transform)
			GameObject.Destroy(t.gameObject);
		highscoreEntryTransformList = new List<Transform>();
		for (int i = 0; i < Highscores.Count; i++) {
			HighscoreEntry highscoreEntry = Highscores.Get(i);
			CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
		}
	}

	[Serializable]
	public class Highscores 
	{
		private static Highscores inst;
		public HighscoreEntry first;
		public HighscoreEntry second;
		public HighscoreEntry third;

		public static Highscores Get() 
		{
			if (inst == null) {
				new Highscores();
			}
			return inst;
		}

		public Highscores() 
		{
			first = new HighscoreEntry();
			second = new HighscoreEntry();
			third = new HighscoreEntry();
			inst = this;

			// Try to load the values
			Load(); // Why this was commented? FIXME !!!! FIXME !!!! FIXME !!!! FIXME !!!! FIXME !!!! FIXME !!!! 

			if (first.time == 0) 
			{
				inst.first.Set("None", 9959997, DateTime.Now.AddDays(-1000));
				inst.second.Set("None", 9959998, DateTime.Now.AddDays(-1000));
				inst.third.Set("None", 9959999, DateTime.Now.AddDays(-1000));
			}
		}

		public static int Count { get { return 3; } } // Constant 3

		internal static void Add(int time, string name) 
		{
			if (inst == null) {
				new Highscores();
			}
		}

		public static HighscoreEntry Get(int i) {
			if (inst == null) {
				new Highscores();
			}
			if (i == 0) return inst.first;
			if (i == 1) return inst.second;
			if (i == 2) return inst.third;
			return new HighscoreEntry();
		}

		public static void Load() {

			PlayerPrefs.DeleteKey("HighScore1" + SceneManager.GetActiveScene());
			PlayerPrefs.DeleteKey("HighScore2" + SceneManager.GetActiveScene());
			PlayerPrefs.DeleteKey("HighScore3" + SceneManager.GetActiveScene());
			if (inst == null) {
				new Highscores();
			}

			string scene = SceneManager.GetActiveScene().name;
			string val = PlayerPrefs.GetString("Highscore_" + scene, "???");
			HighscoreList vals = JsonUtility.FromJson<HighscoreList>(val);
			if (val == "???" || val == "{}" || vals == null) {
				// No highscores for this scene, init them by static values
				inst.first.Set("None", 9959997, DateTime.Now.AddDays(-1000));
				inst.second.Set("None", 9959998, DateTime.Now.AddDays(-1000));
				inst.third.Set("None", 9959999, DateTime.Now.AddDays(-1000));
				return;
			}
			inst.first = vals.first;
			inst.second = vals.second;
			inst.third = vals.third;
		}

	}


	[Serializable]
	public class HighscoreList {
		public HighscoreEntry first;
		public HighscoreEntry second;
		public HighscoreEntry third;

		public HighscoreList(HighscoreEntry a, HighscoreEntry b, HighscoreEntry c) {
			first = a;
			second = b;
			third = c;
		}
	}

	//Represents a single highscore entry
	[Serializable]
	public class HighscoreEntry {
		//public int score;
		public int time;
		public string name;
		public DateTime date;

		public string GetTime() {
			string min = (time / 100000).ToString("00");
			string sec = ((time / 1000) % 100).ToString("00");
			string msec = (time % 1000).ToString("000");
			return min + ":" + sec + ":" + msec;
		}

		public void Set(string n, int t, DateTime d) {
			name = n;
			time = t;
			date = d;
		}

		public string GetDateTime() {
			return date.ToString("R");
		}
	}

}
