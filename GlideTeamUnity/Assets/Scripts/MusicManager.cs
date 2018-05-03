using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

  
    public AudioSource musicSource;


  
    public static MusicManager extend = null;/// For other scripts to call AudioManager
    
    private void Awake() ///instance check
    {
        if (extend == null)
            extend = this;
        else if (extend != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
   
        public void StartInGameMusic(AudioClip GameMusic, params AudioClip [] BGM)	///Persistent Music
		{
        int randomIndex = Random.Range(0, BGM.Length);
            musicSource.clip = GameMusic;
            musicSource.clip = BGM[randomIndex];
            musicSource.Play();
        }
        public void Mute()
        {
            musicSource.Stop();
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
