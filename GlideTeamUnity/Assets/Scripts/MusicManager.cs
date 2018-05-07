using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

  
    public AudioSource musicSource;

	public AudioClip titleScreenMusic;
	public AudioClip classicModeMusic;
	public AudioClip timeAttackMusic;
	public AudioClip powersMusic;
	public AudioClip SceneShift;

  
    public static MusicManager extend = null;/// For other scripts to call AudioManager
    
    private void Awake() ///instance check
    {
        if (extend == null)
            extend = this;
        else if (extend != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
		StartTitleMusic();
    }

	private void Update(){
		float bgmVolumeF = (float) PlayerPrefs.GetInt("BGMVolume", 0) / 100;

		AdjustMusic(bgmVolumeF);
	}

	public void changeBGM(string sceneName){
		if (sceneName.Equals ("ClassicMode"))
			StartClassicModeMusic ();
		else if (sceneName.Equals ("TimeAttack"))
			StartTimeAttackMusic ();
		else if (sceneName.Equals ("PowersMode"))
			StartPowersModeMusic ();
		else if(!musicSource.clip.Equals(titleScreenMusic))
			StartTitleMusic ();

	}

	public void StartTitleMusic()	///Persistent Music
	{
		CancelInvoke ();
		musicSource.clip = titleScreenMusic;
		musicSource.Play();
		Invoke("StartTitleGameMusic", musicSource.clip.length);  ////Plays the next track at random 
	}

	public void StartClassicModeMusic()	///Persistent Music
	{	
		CancelInvoke ();
		musicSource.clip = classicModeMusic;
		musicSource.Play();
		Invoke("StartClassicModeMusic", musicSource.clip.length);  ////Plays the next track at random 
	}

	public void StartTimeAttackMusic()	///Persistent Music
	{	
		CancelInvoke ();
		musicSource.clip = timeAttackMusic;
		musicSource.Play();
		Invoke("StartTimeAttackMusic", musicSource.clip.length);  ////Plays the next track at random 
	}

	public void StartPowersModeMusic()	///Persistent Music
	{	
		CancelInvoke ();
		musicSource.clip = powersMusic;
		musicSource.Play();
		Invoke("StartPowersModeMusic", musicSource.clip.length);  ////Plays the next track at random 
	}

	public void StartSceneShift()
	{
		musicSource.clip = SceneShift;
		musicSource.Play();
	}
      
        public void AdjustMusic(float value)
        {
            if (value < 0 || value > 1)
                return;
            else
                musicSource.volume = value;
        }
    }
