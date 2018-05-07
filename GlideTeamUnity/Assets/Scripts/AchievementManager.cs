using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
	void Start(){
		checkAllAchievments();
		if (PlayerPrefs.GetInt ("AchievementGAMEOVER", 0) == 1)
			GameObject.Find ("GameOverCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("GameOverCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementTEAMTEN", 0) == 1)
			GameObject.Find ("TeamTenCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("TeamTenCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementPLAYERCENTURY", 0) == 1)
			GameObject.Find ("PlayerCenturyCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("PlayerCenturyCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementGRANDMASTER", 0) == 1)
			GameObject.Find ("GrandMasterCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("GrandMasterCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementPARTICIPANT", 0) == 1)
			GameObject.Find ("ParticipantCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("ParticipantCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementPERSISTENT", 0) == 1)
			GameObject.Find ("PersistentCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("PersistentCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementUNYIELDING", 0) == 1)
			GameObject.Find ("UnyieldingCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("UnyieldingCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementSTILLHERE", 0) == 1)
			GameObject.Find ("StillHereCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("StillHereCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementTHECLASSICS", 0) == 1)
			GameObject.Find ("TheClassicsCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("TheClassicsCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementSPEEDDEMON", 0) == 1)
			GameObject.Find ("SpeedDemonCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("SpeedDemonCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementNORULES", 0) == 1)
			GameObject.Find ("NoRulesCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("NoRulesCheck").GetComponent<Toggle>().isOn = false;

		if (PlayerPrefs.GetInt ("AchievementAHIEVEMENTHUNTER", 0) == 1)
			GameObject.Find ("AchievementHunterCheck").GetComponent<Toggle>().isOn = true;
		else
			GameObject.Find ("AchievementHunterCheck").GetComponent<Toggle>().isOn = false;
	}
    public void checkAllAchievments()
    {
        checkAchievementGAMEOVER();
        checkAchievementTEAMTEN();
        checkAchievementPLAYERCENTURY();
        checkAchievementGRANDMASTER();
        checkAchievementPARTICIPANT();
        checkAchievementPERSISTENT();
        checkAchievementUNYIELDING();
        checkAchievementSTILLHERE();
        checkAchievementTHECLASSICS();
        checkAchievementSPEEDDEMON();
        checkAchievementNORULES();
        checkAchievementACHIEVEMENTHUNTER();
    }

    public void clearAllAchievements()
    {
        PlayerPrefs.SetInt("AchievementGAMEOVER", 0);
        PlayerPrefs.SetInt("AchievementTEAMTEN", 0);
        PlayerPrefs.SetInt("AchievementPLAYERCENTURY", 0);
        PlayerPrefs.SetInt("AchievementGRANDMASTER", 0);
        PlayerPrefs.SetInt("AchievementPARTICIPANT", 0);
        PlayerPrefs.SetInt("AchievementPERSISTENT", 0);
        PlayerPrefs.SetInt("AchievementUNYIELDING", 0);
        PlayerPrefs.SetInt("AchievementSTILLHERE", 0);
        PlayerPrefs.SetInt("AchievementTHECLASSICS", 0);
        PlayerPrefs.SetInt("AchievementSPEEDDEMON", 0);
        PlayerPrefs.SetInt("AchievementNORULES", 0);
        PlayerPrefs.SetInt("AchievementACHIEVEMENTHUNTER", 0);
    }

    public void checkAchievementGAMEOVER()
    {
        if (PlayerPrefs.GetInt("TotalGamesPlayed") >= 1)
        {
			PlayerPrefs.SetInt("AchievementGAMEOVER", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementGAMEOVER", 0);
        }
    }

    public void checkAchievementTEAMTEN()
    {
        if (PlayerPrefs.GetInt("TotalGamesPlayed") >= 10)
        {
			PlayerPrefs.SetInt("AchievementTEAMTEN", 1);
        }
        else
        {
			PlayerPrefs.SetInt ("AchievementTEAMTEN", 0);
        }
    }

    public void checkAchievementPLAYERCENTURY()
    {
        if (PlayerPrefs.GetInt("TotalGamesPlayed") >= 100)
        {
			PlayerPrefs.SetInt("AchievementPLAYERCENTURY", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementPLAYERCENTURY", 0);
        }
    }

    public void checkAchievementGRANDMASTER()
    {
        if (PlayerPrefs.GetInt("TotalGamesPlayed") >= 1000)
        {
			PlayerPrefs.SetInt("AchievementGRANDMASTER", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementGRANDMASTER", 0);
        }
    }

    public void checkAchievementPARTICIPANT()
    {
        if (PlayerPrefs.GetInt("CumulativeScore") >= 1000)
        {
			PlayerPrefs.SetInt("AchievementPARTICIPANT", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementPARTICIPANT", 0);
        }
    }

    public void checkAchievementPERSISTENT()
    {
        if (PlayerPrefs.GetInt("CumulativeScore") >= 10000)
        {
			PlayerPrefs.SetInt("AchievementPERSISTENT", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementPERSISTENT", 0);
        }
    }

    public void checkAchievementUNYIELDING()
    {
        if (PlayerPrefs.GetInt("CumulativeScore") >= 100000)
        {
			PlayerPrefs.SetInt("AchievementUNYIELDING", 1);
        }
        else
        {
			PlayerPrefs.SetInt ("AchievementUNYIELDING", 0);
        }
    }

    public void checkAchievementSTILLHERE()
    {
        if (PlayerPrefs.GetInt("CumulativeScore") >= 1000000)
        {
			PlayerPrefs.SetInt("AchievementSTILLHERE", 0);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementSTILLHERE", 0);
        }
    }

    public void checkAchievementTHECLASSICS()
    {
        if (PlayerPrefs.GetInt("ClassicTotalGamesPlayed") >= 100)
        {
			PlayerPrefs.SetInt("AchievementTHECLASSICS", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementTHECLASSICS", 0);
        }
    }

    public void checkAchievementSPEEDDEMON()
    {
        if (PlayerPrefs.GetInt("TimeAttackTotalGamesPlayed") >= 100)
        {
			PlayerPrefs.SetInt("AchievementSPEEDDEMON", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementSPEEDDEMON", 0);
        }
    }

    public void checkAchievementNORULES()
    {
        if (PlayerPrefs.GetInt("PowersTotalGamesPlayed") >= 100)
        {
			PlayerPrefs.SetInt("AchievementNORULES", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementNORULES", 0);
        }
    }

    public void checkAchievementACHIEVEMENTHUNTER()
    {
        if (PlayerPrefs.GetInt("AchievementGAMEOVER") == 1 &&
        PlayerPrefs.GetInt("AchievementTEAMTEN") == 1 &&
        PlayerPrefs.GetInt("AchievementPLAYERCENTURY") == 1 &&
        PlayerPrefs.GetInt("AchievementGRANDMASTER") == 1 && 
        PlayerPrefs.GetInt("AchievementPARTICIPANT") == 1 && 
        PlayerPrefs.GetInt("AchievementPERSISTENT") == 1 &&
        PlayerPrefs.GetInt("AchievementUNYIELDING") == 1 &&
        PlayerPrefs.GetInt("AchievementSTILLHERE") == 1 &&
        PlayerPrefs.GetInt("AchievementTHECLASSICS") == 1 &&
        PlayerPrefs.GetInt("AchievementSPEEDDEMON") == 1 &&
        PlayerPrefs.GetInt("AchievementNORULES") == 1)
        {
			PlayerPrefs.SetInt("AchievementACHIEVEMENTHUNTER", 1);
        }
        else
        {
			PlayerPrefs.SetInt("AchievementACHIEVEMENTHUNTER", 0);
        }
    }
}
