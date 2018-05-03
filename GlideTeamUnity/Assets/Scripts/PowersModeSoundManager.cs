using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersModeSoundManager : SoundManager  {


    
    public AudioClip DropBombBlock;
    public AudioClip ScoreMultiplier;
    public AudioClip WildBlockStart;

     ///Specific audio clips
  
    public void StartDropBombBlock()
    {
        soundSource.clip = DropBombBlock;
        soundSource.Play();

    }
    public void StartScoreMultiply()
    {
        soundSource.clip = ScoreMultiplier;
        soundSource.Play();
    }
    public void StartWildBlock()
    {
        soundSource.clip = WildBlockStart;
        soundSource.Play();

    }
}
