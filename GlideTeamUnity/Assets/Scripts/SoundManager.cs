using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource soundSource;

    public AudioClip dropSound; /// Specific audio clips played when requirements are met.
    public AudioClip LineClearing;
    public AudioClip GameMusic;
    public AudioClip WinTheme;
    public AudioClip LoseTheme;
    public AudioClip Interaction;
    public AudioClip SceneShift;
    public AudioClip SetBlock;


    public void StartWinTheme() ///Specific audio clips
    {

        soundSource.clip = WinTheme;
        soundSource.Play();
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
    public void StartdropSound()
    {
        soundSource.clip = dropSound;
        soundSource.Play();
    }
    public void StartSceneShift()
    {
        soundSource.clip = SceneShift;
        soundSource.Play();
    }
    public void StartBlockSet()
    {
        soundSource.clip = SetBlock;
        soundSource.Play();
    }
    public void AdjustSoundFX(float value)  ///Volume Adjustment methods
    {
        float temp = value + soundSource.volume;
        if (temp < 0 || temp > 1)
            return;
        else
            soundSource.volume += value;
    }
}
  



