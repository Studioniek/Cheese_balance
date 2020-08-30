using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
	public float timeStart = 3;
	//public float timeEnd = 0;
	public Text textBox;
	public float DelayStartText = 1f;
	void Start()
	{
		textBox.text = timeStart.ToString();

		//Time.timeScale = 1;
	
	}

    // Update is called once per frame
    void Update()
    {
		timeStart -=Time.deltaTime;
		textBox.text = Mathf.Round(timeStart).ToString("0");
		if (textBox.text == "0")
		{
			textBox.text = "GO!";
		}
	
		if (textBox.text == "GO!")
		{
		//	Invoke("Stop", DelayStartText);
		}
	}
}
