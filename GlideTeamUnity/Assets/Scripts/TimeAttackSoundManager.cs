using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttackSoundManager : SoundManager {

    public AudioClip TimerOut;
    public float Timer = 5; /// 5 second timer

    public void Update()
    {
    

        if (Timer > 5)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            soundSource.clip = TimerOut;
            soundSource.Play();
        }
    
        
    }

}
