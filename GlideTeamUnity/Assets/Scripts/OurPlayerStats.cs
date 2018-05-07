using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OurPlayerStats : MonoBehaviour {
	public int CumulativeScore = 0;
	public int TotalGamesPlayed = 0;

	public int ClassicHiScore = 0;
	public int ClassicTotalScore = 0;
	public double ClassicAvgScore = 0;
	public int ClassicTotalGamesPlayed = 0;

	public int TimeAttackHiScore = 0;
	public int TimeAttackTotalScore = 0;
	public double TimeAttackAvgScore = 0;
	public int TimeAttackTotalGamesPlayed = 0;
	/*
	public int PowersHiScore = 0;
	public int PowersTotalScore = 0;
	public double PowersAvgScore = 0;
	public int PowersTotalGamesPlayed = 0;
*/
	public Text classicHighScoreText;
	public Text classicAvgScoreText;
	public Text classicTotalScoreText;
	public Text classicTotalGamesPlayedText;

	public Text timeAttackHighScoreText;
	public Text timeAttackAvgScoreText;
	public Text timeAttackTotalScoreText;
	public Text timeAttackTotalGamesPlayedText;
	/*
	public Text powersHighScoreText;
	public Text powersAvgScoreText;
	public Text powersTotalScoreText;
	public Text powersTotalGamesPlayedText;*/

	public Text cumulativeScoreText;
	public Text totalGamesPlayedText;

	public int getCumulativeScore (){
		return CumulativeScore;
	}

	void Start (){
		CumulativeScore = PlayerPrefs.GetInt ("CumulativeScore", 0);
		TotalGamesPlayed = PlayerPrefs.GetInt("TotalGamesPlayed", 0);

		ClassicHiScore = PlayerPrefs.GetInt ("ClassicHighScore", 0);
		ClassicTotalScore = PlayerPrefs.GetInt ("ClassicTotalScore", 0);
		ClassicAvgScore = PlayerPrefs.GetInt ("ClassicAvgScore", 0);
		ClassicTotalGamesPlayed = PlayerPrefs.GetInt ("ClassicTotalGamesPlayed", 0);

		TimeAttackHiScore = PlayerPrefs.GetInt ("TimeAttackHighScore", 0);
		TimeAttackTotalScore = PlayerPrefs.GetInt ("TimeAttackTotalScore", 0);
		TimeAttackAvgScore = PlayerPrefs.GetInt ("TimeAttackAvgScore", 0);
		TimeAttackTotalGamesPlayed = PlayerPrefs.GetInt ("TimeAttackTotalGamesPlayed", 0);

		CumulativeScore = PlayerPrefs.GetInt("CumulativeScore", 0);
		TotalGamesPlayed = PlayerPrefs.GetInt("TotalGamesPlayed", 0);


		classicHighScoreText.text = ClassicHiScore.ToString ();
		classicAvgScoreText.text = ClassicAvgScore.ToString ();
		classicTotalScoreText.text = ClassicTotalScore.ToString ();
		classicTotalGamesPlayedText.text = ClassicTotalGamesPlayed.ToString ();

		timeAttackHighScoreText.text =TimeAttackHiScore.ToString ();
		timeAttackAvgScoreText.text = TimeAttackTotalScore.ToString ();
		timeAttackTotalScoreText.text = TimeAttackTotalScore.ToString ();
		timeAttackTotalGamesPlayedText.text = TimeAttackTotalGamesPlayed.ToString ();

		cumulativeScoreText.text = CumulativeScore.ToString ();
		totalGamesPlayedText.text = TotalGamesPlayed.ToString ();
		/*
		powersHighScoreText.text = PlayerPrefs.GetInt ("PowersHighScore", 0).ToString ();
		powersAvgScoreText.text = PlayerPrefs.GetInt ("PowersAvgScore", 0).ToString ();
		powersTotalScoreText.text = PlayerPrefs.GetInt ("PowersTotalScore", 0).ToString ();
		powersTotalGamesPlayedText.text = PlayerPrefs.GetInt ("PowersTotalGamesPlayed", 0).ToString ();*/
	}

	void WipeStats()
	{
		CumulativeScore = 0;
		TotalGamesPlayed = 0;

		ClassicHiScore = 0;
		ClassicTotalScore = 0;
		ClassicAvgScore = 0;
		ClassicTotalGamesPlayed = 0;

		TimeAttackHiScore = 0;
		TimeAttackTotalScore = 0;
		TimeAttackAvgScore = 0;
		TimeAttackTotalGamesPlayed = 0;
		/*
		PowersHiScore = 0;
		PowersTotalScore = 0;
		PowersAvgScore = 0;
		PowersTotalGamesPlayed = 0;
*/
		PlayerPrefs.SetInt ("CumulativeScore", 0);
		PlayerPrefs.SetInt ("TotalGamesPlayed", 0);

		PlayerPrefs.SetInt ("ClassicHighScore", 0);
		PlayerPrefs.SetInt ("ClassicTotalScore", 0);
		PlayerPrefs.SetInt ("ClassicAvgScore", 0);
		PlayerPrefs.SetInt ("ClassicTotalGamesPlayed", 0);

		PlayerPrefs.SetInt ("TimeAttackHiScore", 0);
		PlayerPrefs.SetInt ("TimeAttackTotalScore", 0);
		PlayerPrefs.SetInt ("TimeAttackAvgScore", 0);
		PlayerPrefs.SetInt ("TimeAttackTotalGamesPlayed", 0);

		CumulativeScore = PlayerPrefs.GetInt ("CumulativeHighScore", 0);
		TotalGamesPlayed = PlayerPrefs.GetInt("TotalGamesPlayed", 0);

		ClassicHiScore = PlayerPrefs.GetInt ("ClassicHighScore", 0);
		ClassicTotalScore = PlayerPrefs.GetInt ("ClassicTotalScore", 0);
		ClassicAvgScore = PlayerPrefs.GetInt ("ClassicAvgScore", 0);
		ClassicTotalGamesPlayed = PlayerPrefs.GetInt ("ClassicTotalGamesPlayed", 0);

		TimeAttackHiScore = PlayerPrefs.GetInt ("TimeAttackHighScore", 0);
		TimeAttackTotalScore = PlayerPrefs.GetInt ("TimeAttackTotalScore", 0);
		TimeAttackAvgScore = PlayerPrefs.GetInt ("TimeAttackAvgScore", 0);
		TimeAttackTotalGamesPlayed = PlayerPrefs.GetInt ("TimeAttackTotalGamesPlayed", 0);

		CumulativeScore = PlayerPrefs.GetInt("CumulativeScore", 0);
		TotalGamesPlayed = PlayerPrefs.GetInt("TotalGamesPlayed", 0);

		classicHighScoreText.text = ClassicHiScore.ToString ();
		classicAvgScoreText.text = ClassicAvgScore.ToString ();
		classicTotalScoreText.text = ClassicTotalScore.ToString ();
		classicTotalGamesPlayedText.text = ClassicTotalGamesPlayed.ToString ();

		timeAttackHighScoreText.text =TimeAttackHiScore.ToString ();
		timeAttackAvgScoreText.text = TimeAttackTotalScore.ToString ();
		timeAttackTotalScoreText.text = TimeAttackTotalScore.ToString ();
		timeAttackTotalGamesPlayedText.text = TimeAttackTotalGamesPlayed.ToString ();

		cumulativeScoreText.text = CumulativeScore.ToString ();
		totalGamesPlayedText.text = TotalGamesPlayed.ToString ();
		/*
		PlayerPrefs.SetInt ("PowersHighScore", Powers);
		powersHighScoreText.text = PlayerPrefs.GetInt ("PowersHighScore", 0).ToString ();
		PlayerPrefs.SetInt ("PowersAvgScore", 0);
		powersAvgScoreText.text = PlayerPrefs.GetInt ("PowersAvgScore", 0).ToString ();
		PlayerPrefs.SetInt ("PowersTotalScore", 0);
		powersTotalScoreText.text = PlayerPrefs.GetInt ("PowersTotalScore", 0).ToString ();
		PlayerPrefs.SetInt ("PowersTotalGamesPlayed", 0);
		powersTotalGamesPlayedText.text = PlayerPrefs.GetInt ("PowersTotalGamesPlayed", 0).ToString ();*/
	}
}