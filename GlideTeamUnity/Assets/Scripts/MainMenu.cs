using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	/*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            
		
	}*/

	IEnumerator DelaySceneLoad(string sceneName)
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		GameObject.Find ("Music Manager").GetComponent<MusicManager> ().changeBGM(sceneName);
		SceneManager.LoadScene(sceneName);
	}

    public void changeMenuScene(string sceneName)
    {
		SceneManager.LoadScene(sceneName);

    }

	public void changeMenuSceneSound(string sceneName)
	{
		StartCoroutine(DelaySceneLoad(sceneName));

	}

}
