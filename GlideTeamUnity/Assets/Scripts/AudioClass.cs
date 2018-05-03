using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClass : MonoBehaviour {
  /// Persistently played background audio throughout the game.

    public AudioSource musicSource;
    public AudioSource soundSource;

    public AudioClip dropSound; /// Specific audio clips played when requirements are met.
    public AudioClip LineClearing;
    public AudioClip titleScreenMusic;
	public AudioClip classicModeMusic;
	public AudioClip timeAttackMusic;
	public AudioClip powersMusic;
    public AudioClip WinTheme;
    public AudioClip LoseTheme;
    public AudioClip SceneShift;
    public AudioClip BlockSet;



    public static AudioClass extend = null;/// For other scripts to call AudioClass
    

    private void Awake() ///instance check
    {
        if (extend == null)
            extend = this;
        else if (extend != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
		StartTitleMusic ();
    }

	private void Update(){
		float bgmVolumeF = (float) PlayerPrefs.GetInt("BGMVolume", 0) / 100;
		float sfxVolumeF = (float) PlayerPrefs.GetInt("SFXVolume", 0) / 100;

		AdjustMusic(bgmVolumeF);
		AdjustSoundFX(sfxVolumeF);
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
    public void StartWinTheme() ///Specific audio clips
    {
        Mute();
        soundSource.clip = WinTheme;
        soundSource.Play();
    }
    public void StartLoseTheme()
    {
        Mute();
        soundSource.clip = LoseTheme;
        soundSource.Play();
    }
    public void StartInteractionSound(AudioClip Interaction)
    {
        soundSource.clip = Interaction;
        soundSource.Play();
    }
    public void StartLineClearingSound(AudioClip LineClearing)
    {
        soundSource.clip = LineClearing;
    }
        public void StartDropSound()
        {
            soundSource.clip = dropSound;
            soundSource.Play();
        }
        public void StartSceneShift(AudioClip SceneShift)
        {
        soundSource.clip = SceneShift;
        soundSource.Play();
        }
    public void StartBlockSet(AudioClip SetBlock)
    {
        soundSource.clip = SetBlock;
        soundSource.Play();
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
        public void Mute()
        {
            musicSource.Stop();
        }
        public void AdjustSoundFX(float value)	///Volume Adjustment methods
		{
            float temp = value + soundSource.volume;
            if (temp < 0 || temp > 1)
                return;
            else
                soundSource.volume += value;
        }
        public void AdjustMusic(float value)
        {
          
                musicSource.volume = value;
        }
    }
