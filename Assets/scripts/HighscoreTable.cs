using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class HighscoreTable : MonoBehaviour 

//When pressing button1 open level 1 scorelist.
//When pressing x or level 2 delete clone list and load scorelist level 2
//if score list is not made yet get list from default
//????//


{
	public string LevelNSelect;
	string LevelNameSelect;
	private Transform entryContainer; 
	public Transform entryTemplate;
	//public List<HighscoreEntry> highscoreEntryList;
	public List<Transform> highscoreEntryTransformList;
	public GameObject HighscoretableOn;




	public void getlevelName ()
		{
		
		var LevelName = EventSystem.current.currentSelectedGameObject.name;
			LevelNSelect = EventSystem.current.currentSelectedGameObject.name;
		//var level = LevelNSelect;


		//Highscoretabel.gameObject.SetActive(true);
			print (LevelName);//-------
	
			LevelNameSelect = LevelNSelect.ToString();
			//Text LevelNameSelect.text();
		
			print(LevelNameSelect);
			entryContainer = transform.Find("highscoreEntryContainer");
		//string val = PlayerPrefs.GetString("Highscore_" + EventSystem.current.currentSelectedGameObject.name, "???"); 
		//string val = PlayerPrefs.GetString("Highscore_" + "LVL_001", "???");
		//string val2 = PlayerPrefs.GetString("Highscore_" + "LVL_002", "???");
	}

	public void destroyList()
	{
		//PlayerPrefs.GetInt.SetActive(0,0);
		var LevelName = EventSystem.current.currentSelectedGameObject.name;


		entryContainer = transform.Find("highscoreEntryContainer");
				foreach(Transform t in entryContainer) 
		{
					GameObject.Destroy(t.gameObject);
	}
	}
	public void GetScoreList() 
	{

		entryContainer = transform.Find("highscoreEntryContainer");
		foreach(Transform t in entryContainer) {
			GameObject.Destroy(t.gameObject);
		}
		entryTemplate.gameObject.SetActive(false);

		if (Highscores.Get(0).time == 0) 
		{
			// There's no stored table, initialize
			Debug.Log("Initializing table with default values...");
			AddHighscoreEntry(2005001, "Nik");
			AddHighscoreEntry(1010002, "CPU");
			AddHighscoreEntry(0040003, "CP2");
		}

		highscoreEntryTransformList = new List<Transform>();
		for (int i = 0; i < Highscores.Count; i++) 
		{
			HighscoreEntry highscoreEntry = Highscores.Get(i);
			CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
		}
	
	
	}



	//-------------------
	private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) 
	{
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
	//-----------------------------
	public void AddHighscoreEntry(int time, string name) 
	{
		Highscores.Add(time, name);
		Highscores.Save();

		foreach (Transform t in entryContainer.transform)
			GameObject.Destroy(t.gameObject);
		highscoreEntryTransformList = new List<Transform>();
		for (int i = 0; i < Highscores.Count; i++) 
		{
			HighscoreEntry highscoreEntry = Highscores.Get(i);
			CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
		}
	}
	//------------------------
	[Serializable]
	public class Highscores 
	{
		private static Highscores inst;
		public HighscoreEntry first;
		public HighscoreEntry second;
		public HighscoreEntry third;

		public static Highscores Get() 
		{
			if (inst == null) 
			{
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
			if (inst == null) 
			{
				new Highscores();
			}

			if (time < inst.first.time) 
			{
				inst.third.name = inst.second.name;
				inst.second.name = inst.first.name;
				inst.third.time = inst.second.time;
				inst.second.time = inst.first.time;
				inst.third.date = inst.second.date; // FIMXE <- new code to handle the dates
				inst.second.date = inst.first.date;
				inst.first.name = name;
				inst.first.time = time;
				inst.first.date = DateTime.Now;
				Save();
			}
			else if (time < inst.second.time) 
			{
				inst.third.name = inst.second.name;
				inst.third.time = inst.second.time;
				inst.third.date = inst.second.date;
				inst.second.name = name;
				inst.second.time = time;
				inst.second.date = DateTime.Now;
				Save();
			}
			else if (time < inst.third.time) 
			{
				inst.third.name = name;
				inst.third.time = time;
				inst.third.date = DateTime.Now;
				Save();
			}
		}

		public static HighscoreEntry Get(int i) 
		{
			if (inst == null) 
			{
				new Highscores();
			}
			if (i == 0) return inst.first;
			if (i == 1) return inst.second;
			if (i == 2) return inst.third;
			return new HighscoreEntry();
		}

		public static void Save() 
		{
			if (inst == null) 
			{
				return;
			}
			string scene = SceneManager.GetActiveScene().name;
			HighscoreList list = new HighscoreList(inst.first, inst.second, inst.third);
			PlayerPrefs.SetString("Highscore_" + scene, JsonUtility.ToJson(list));
			PlayerPrefs.Save();
		}

		//public static void Load() 
		public void Load() 
		{
			string scene = SceneManager.GetActiveScene().name;


			if (inst == null) 
			{
				new Highscores();
			}
//
		
//		
		string val = PlayerPrefs.GetString("Highscore_" + EventSystem.current.currentSelectedGameObject.name, "???");
			HighscoreList vals = null;
			try 
			{
				//if (val != "???" && val != "{}")
					vals = JsonUtility.FromJson<HighscoreList>(val);
			} catch (System.Exception) {
				Debug.Log("Warning, illegal JSON to parse: " + val);
			}
			if (vals == null) 
			{
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
	//-----------------------------
	[Serializable]
	public class HighscoreList 
	{
		public HighscoreEntry first;
		public HighscoreEntry second;
		public HighscoreEntry third;

		public HighscoreList(HighscoreEntry a, HighscoreEntry b, HighscoreEntry c) 
		{
			first = a;
			second = b;
			third = c;
		}
	}
	//0--------------------
	[Serializable]
	public class HighscoreEntry 
	{
		//public int score;
		public int time;
		public string name;
		public DateTime date;

		public string GetTime() 
		{
			string min = (time / 100000).ToString("00");
			string sec = ((time / 1000) % 100).ToString("00");
			string msec = (time % 1000).ToString("000");
			return min + ":" + sec + ":" + msec;
		}

		public void Set(string n, int t, DateTime d) 
		{
			name = n;
			time = t;
			date = d;
		}

		public string GetDateTime() 
		{
			return date.ToString("R");
		}
	}

	public void DeleteScoreList() 
	{
		
	}

	public void Select () //hiermee moet je naar het level
		{
			//SceneManager.LoadScene(LevelName);
			//LevelName = "0";
			//LevelNSelect = "0";
	
		}

	public void DestroyClone ()
	{
		

//			string scene = SceneManager.GetActiveScene().name;
//
			//PlayerPrefs.GetString("Highscore_" + "LVL_002", "???");
//			HighscoreList vals = null;
//			try 
//			{
//				if (val != "???" && val != "{}")
//					vals = JsonUtility.FromJson<HighscoreList>(val);
//			} catch (System.Exception) {
//				Debug.Log("Warning, illegal JSON to parse: " + val);
//			}
//			if (vals == null) 
//			{
//				// No highscores for this scene, init them by static values
//				inst.first.Set("None", 9959997, DateTime.Now.AddDays(-1000));
//				inst.second.Set("None", 9959998, DateTime.Now.AddDays(-1000));
//				inst.third.Set("None", 9959999, DateTime.Now.AddDays(-1000));
//				return;
//			}
//			inst.first = vals.first;
//			inst.second = vals.second;
//			inst.third = vals.third;
		}
}

