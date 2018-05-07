using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public int currentGameMode;
    public int gameModeHiScore;
    public int currentScore;
	public Text InGameScore;

    public static scoreManager scoreChart = null;

    private void checkCurrentGameMode()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (sceneName == "ClassicMode")
            {
                gameModeHiScore =  PlayerPrefs.GetInt("ClassicHighScore");
                currentGameMode= 1;
            }
            else if (sceneName == "TimeAttack")
            {
                gameModeHiScore = PlayerPrefs.GetInt("TimeAttackHighScore");
                currentGameMode= 2;
            }
            else if (sceneName == "PowersMode")
            {
                gameModeHiScore = PlayerPrefs.GetInt("PowersHighScore");
                currentGameMode= 3;
            }
            else
            {
                gameModeHiScore = 0;
            }
        }
        
        private void Awake()
        {
            checkCurrentGameMode();
		currentScore = 0;
            //Managers.UI.inGameUI.UpdateScoreUI(); // Dipslay score on UI if used
        }

        public void UpdateScore(int UpdateValue)
		{
		GameObject.Find ("Sound Manager").GetComponent<SoundManager> ().StartLineClearingSound();
            currentScore += UpdateValue;
		InGameScore.text = currentScore.ToString();
            CheckgameModeHiScore();
            //Managers.UI.inGameUI.UpdateScoreUI(); // Dipslay score on UI if used
            int newCumulativeScore = (PlayerPrefs.GetInt("CumulativeScore")) + UpdateValue;
            PlayerPrefs.SetInt("CumulativeScore", newCumulativeScore);

			if (currentGameMode == 2)
			{
				GameObject.Find ("Timer").GetComponent<Timer> ().Addtime();
			}
        }

        public void CheckgameModeHiScore()
        {
            if (gameModeHiScore < currentScore)
            {
                gameModeHiScore = currentScore;
            }
        }
        
        public void UpdateStats()
        {
            int temp0 = (PlayerPrefs.GetInt("TotalGamesPlayed")) + 1;
            PlayerPrefs.SetInt("TotalGamesPlayed", temp0);

            if (currentGameMode== 1)
            {
                if (gameModeHiScore <= currentScore)
                {
                    PlayerPrefs.SetInt("ClassicHighScore", currentScore);
                }
                int temp1 = (PlayerPrefs.GetInt("ClassicTotalScore")) + currentScore;
                             PlayerPrefs.SetInt("ClassicTotalScore", temp1);

                int temp2 = (PlayerPrefs.GetInt("ClassicTotalGamesPlayed")) + 1;
                             PlayerPrefs.SetInt("ClassicTotalGamesPlayed", temp2);

                double avg = (temp1/temp2);
				int temp3 = (int) avg;
                             PlayerPrefs.SetInt("ClassicAvgScore", temp3);
            }
            else if (currentGameMode== 2)
            {
                if (gameModeHiScore <= currentScore)
                {
                    PlayerPrefs.SetInt("TimeAttackHighScore", currentScore);
                }
                int temp1 = (PlayerPrefs.GetInt("TimeAttackTotalScore")) + currentScore;
                             PlayerPrefs.SetInt("TimeAttackTotalScore", temp1);

                int temp2 = (PlayerPrefs.GetInt("TimeAttackTotalGamesPlayed")) + 1;
                             PlayerPrefs.SetInt("TimeAttackTotalGamesPlayed", temp2);

                double avg = (temp1 / temp2);
				int temp3 = (int) avg;
                             PlayerPrefs.SetInt("TimeAttackAvgScore", temp3);
            }
            else if (currentGameMode== 3)
            {
                if (gameModeHiScore <= currentScore)
                {
                    PlayerPrefs.SetInt("PowersHighScore", currentScore);
                }
                int temp1 = (PlayerPrefs.GetInt("PowersTotalScore")) + currentScore;
                             PlayerPrefs.SetInt("PowersTotalScore", temp1);

                int temp2 = (PlayerPrefs.GetInt("PowersTotalGamesPlayed")) + 1;
                             PlayerPrefs.SetInt("PowersTotalGamesPlayed", temp2);

                double avg = (temp1 / temp2);
				int temp3 = (int)avg;
                PlayerPrefs.SetInt("PowersAvgScore", temp3);
            }
        }

        public void ResetScore()
        {
            currentScore = 0;
            checkCurrentGameMode();
            //Managers.UI.inGameUI.UpdateScoreUI(); Update UI if used
        }

}
