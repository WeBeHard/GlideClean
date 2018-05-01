using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    public int CurrentGameMode = 0;
    public int GameModeHiScore = 0;
    public int CurrentScore = 0;

    public static scoreManager scoreChart = null;

    private void checkCurrentGameMode()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (sceneName == "ClassicMode")
            {
                GameModeHiScore =  PlayerPrefs.GetInt("ClassicHighScore");
                CurrentGameMode = 1;
            }
            else if (sceneName == "TimeAttack")
            {
                GameModeHiScore = PlayerPrefs.GetInt("TimeAttackHighScore");
                CurrentGameMode = 2;
            }
            else if (sceneName == "PowersMode")
            {
                GameModeHiScore = PlayerPrefs.GetInt("PowersHighScore");
                CurrentGameMode = 3;
            }
            else
            {
                GameModeHiScore = 0;
            }
        }
        
        private void Awake()
        {
            checkCurrentGameMode();
            //Managers.UI.inGameUI.UpdateScoreUI(); // Dipslay score on UI if used
        }

        public void UpdateScore(int UpdateValue)
        {
            CurrentScore += UpdateValue;
            CheckGameModeHiScore();
            //Managers.UI.inGameUI.UpdateScoreUI(); // Dipslay score on UI if used
            int newCumulativeScore = (PlayerPrefs.GetInt("CumulativeScore")) + UpdateValue;
            PlayerPrefs.SetInt("CumulativeScore", newCumulativeScore);
        }

        public void CheckGameModeHiScore()
        {
            if (GameModeHiScore < CurrentScore)
            {
                GameModeHiScore = CurrentScore;
            }
        }
        
        void UpdateStats()
        {
            int temp0 = (PlayerPrefs.GetInt("TotalGamesPlayed")) + 1;
            PlayerPrefs.SetInt("TotalGamesPlayed", temp0);

            if (CurrentGameMode == 1)
            {
                if (GameModeHiScore <= CurrentScore)
                {
                    PlayerPrefs.SetInt("ClassicHighScore", CurrentScore);
                }
                int temp1 = (PlayerPrefs.GetInt("ClassicTotalScore")) + CurrentScore;
                             PlayerPrefs.SetInt("ClassicTotalScore", temp1);

                int temp2 = (PlayerPrefs.GetInt("ClassicTotalGamesPlayed")) + 1;
                             PlayerPrefs.SetInt("ClassicTotalGamesPlayed", temp2);

                double avg = (temp1/temp2);
				int temp3 = (int) avg;
                             PlayerPrefs.SetInt("ClassicAvgScore", temp3);
            }
            else if (CurrentGameMode == 2)
            {
                if (GameModeHiScore <= CurrentScore)
                {
                    PlayerPrefs.SetInt("TimeAttackHighScore", CurrentScore);
                }
                int temp1 = (PlayerPrefs.GetInt("TimeAttackTotalScore")) + CurrentScore;
                             PlayerPrefs.SetInt("TimeAttackTotalScore", temp1);

                int temp2 = (PlayerPrefs.GetInt("TimeAttackTotalGamesPlayed")) + 1;
                             PlayerPrefs.SetInt("TimeAttackTotalGamesPlayed", temp2);

                double avg = (temp1 / temp2);
				int temp3 = (int) avg;
                             PlayerPrefs.SetInt("TimeAttackAvgScore", temp3);
            }
            else if (CurrentGameMode == 3)
            {
                if (GameModeHiScore <= CurrentScore)
                {
                    PlayerPrefs.SetInt("PowersHighScore", CurrentScore);
                }
                int temp1 = (PlayerPrefs.GetInt("PowersTotalScore")) + CurrentScore;
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
            CurrentScore = 0;
            checkCurrentGameMode();
            //Managers.UI.inGameUI.UpdateScoreUI(); Update UI if used
        }

}
