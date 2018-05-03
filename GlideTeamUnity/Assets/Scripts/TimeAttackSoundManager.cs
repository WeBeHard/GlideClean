using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttackSoundManager : SoundManager {

    public AudioClip TimerOut;

    public void StartCountDownTimer()
    {
        soundSource.clip = TimerOut;
        soundSource.Play();

    }

}
