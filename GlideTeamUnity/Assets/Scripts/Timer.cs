	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : GridManager {

	public Text timeText;
	public float timeStamp;
	public bool usingTimer;
	float timeLeft = 20.0f;

	public float seconds, minutes;

	// Use this for initialization
	void Start () {
		//setTimer (30);
	}

	public void Addtime()
	{
		timeLeft += 15.0f;
	}

	// Update is called once per frame
	void Update () {
		
		timeLeft -= Time.deltaTime;
		string timer = ((int)timeLeft).ToString ("00");
		timeText.text = timer;
		if(timeLeft <= 0)
		{
			GameObject.Find ("LoseBlock").GetComponent<Block> ().GameOver(true);
			Destroy (this);
		}
		/*
		if (fullRows.Count != 0 || fullColumns.Count != 0) {

			int extraTime = fullRows.Count + fullColumns.Count;

			timeLeft += extraTime * 15.0f;
		}*/
	}
		

}
