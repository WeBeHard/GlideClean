using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {
	public Text currentScore;
	public Text highScore;
    //GameObject.Find("High Score").GetComponent<Text>().text = PlayerPrefs.GetInt("ClassicHighScore", 0);
    //GameObject.Find("High Score").GetComponent<Text>().text = PlayerPrefs.GetInt("ClassicHighScore", 0).toString();

	void Update(){
		currentScore.text = GameObject.Find ("GameController").GetComponent<scoreManager>().currentScore.ToString();
		highScore.text = GameObject.Find ("GameController").GetComponent<scoreManager>().gameModeHiScore.ToString();
	}
}
