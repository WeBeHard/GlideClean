using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClass : MonoBehaviour {

    public AudioSource musicSource; /// Persistently played background audio throughout the game.
    public AudioClip[] BGM;
    public AudioSource soundSource;

    public AudioClip dropSound; /// Specific audio clips played when requirements are met.
    public AudioClip LineClearing;
    public AudioClip GameMusic;
    public AudioClip WinTheme;
    public AudioClip LoseTheme;
    public AudioClip Interaction;
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
    }
    public void StartWinTheme(AudioClip WinTheme) ///Specific audio clips
    {
        Mute();
        soundSource.clip = WinTheme;
        soundSource.Play();
    }
    public void StartLoseTheme(AudioClip LoseTheme)
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
        public void StartdropSound(AudioClip dropSound)
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
        public void StartInGameMusic()	///Persistent Music
		{
        int Soundtrack = Random.Range(0, BGM.Length);
            musicSource.clip = BGM[Soundtrack];
            musicSource.Play();
            Invoke("StartInGameMusic", musicSource.clip.length);  ////Plays the next track at random 
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
            float temp = value + musicSource.volume;
            if (temp < 0 || temp > 1)
                return;
            else
                musicSource.volume += value;
        }
    }
