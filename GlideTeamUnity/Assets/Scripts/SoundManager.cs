using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource soundSource;

    public AudioClip dropSound; /// Specific audio clips played when requirements are met.
    public AudioClip LineClearing;
    public AudioClip LoseTheme;
    public AudioClip Interaction;
	public AudioClip SetBlock;
	public static SoundManager lend = null;

	private void Update(){
		float sfxVolumeF = (float) PlayerPrefs.GetInt("SFXVolume", 0) / 100;
		AdjustSoundFX(sfxVolumeF);
	}

    public void StartLoseTheme()
    {
        soundSource.clip = LoseTheme;
        soundSource.Play();
    }

    public void StartInteractionSound()
    {
        soundSource.clip = Interaction;
        soundSource.Play();
    }

    public void StartLineClearingSound()
    {
        soundSource.clip = LineClearing;
        soundSource.Play();
    }

    public void StartDropSound()
    {
        soundSource.clip = dropSound;
        soundSource.Play();
    }
    
	public void StartBlockSet()
    {
        soundSource.clip = SetBlock;
        soundSource.Play();
    }

	public void Mute()
	{
		GameObject.Find ("Music Manager").GetComponent<MusicManager> ().musicSource.Stop();
	}

    public void AdjustSoundFX(float value)  ///Volume Adjustment methods
    {
        if (value < 0 || value > 1)
            return;
        else
            soundSource.volume = value;
    }
}
  



