using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Options : MonoBehaviour {

	public Slider BGMSlider;
	public Slider SFXSlider;
	public AudioSource bgmAudio;
	public AudioSource sfxAudio;
	public int bgmVolume;
	public int sfxVolume;

	void Start () {
		bgmVolume = PlayerPrefs.GetInt("BGMVolume", 0);
		sfxVolume = PlayerPrefs.GetInt("SFXVolume", 0);
		float bgmVolumeF = (float)bgmVolume / 100;
		float sfxVolumeF = (float)sfxVolume / 100;

		BGMSlider.value = bgmVolumeF;
		SFXSlider.value = sfxVolumeF;
    }
    

    void Update () {
		bgmVolume = Mathf.RoundToInt(BGMSlider.value * 100);
		sfxVolume = Mathf.RoundToInt(SFXSlider.value * 100);
		PlayerPrefs.SetInt ("BGMVolume", bgmVolume);
		PlayerPrefs.SetInt ("SFXVolume", sfxVolume);
    } 



	public void changeBGMVolume (){
		BGMSlider.value = bgmAudio.volume;
	}

	public void changeSFXVolume(){
		SFXSlider.value = sfxAudio.volume;
	}

} 

