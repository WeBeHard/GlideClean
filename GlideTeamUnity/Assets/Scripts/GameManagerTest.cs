using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour {

	// grid
	//Grid grid;

	// 3 spawners
	Spawner leftSpawner;
	Spawner middleSpawner;
	Spawner rightSpawner;

	// holder
	//Holder holder;

	//// game over
	//bool gameOver = false;

	//// game over panel
	//public GameObject gameOverPanel;

	//// pause
	//public bool pause = false;

	//// pause panel
	//public GameObject pausePanel;

	// Use this for initialization
	void Start () {
		//grid = FindObjectOfType<Grid>();
		leftSpawner = GameObject.Find("LeftSpawner").GetComponent<Spawner>();
		middleSpawner = GameObject.Find("MiddleSpawner").GetComponent<Spawner>();
		rightSpawner = GameObject.Find("RightSpawner").GetComponent<Spawner>();
		//holder = FindObjectOfType<Holder>();
	}

	// Update is called once per frame
	void Update () {
		leftSpawner = GameObject.Find("LeftSpawner").GetComponent<Spawner>();
		middleSpawner = GameObject.Find("MiddleSpawner").GetComponent<Spawner>();
		rightSpawner = GameObject.Find("RightSpawner").GetComponent<Spawner>();
		if (leftSpawner.IsEmpty() == true && middleSpawner.IsEmpty() == true && rightSpawner.IsEmpty() == true)
		{
			leftSpawner.SpawnBlock();
			middleSpawner.SpawnBlock();
			rightSpawner.SpawnBlock();
		}
		//if (gameOver)
		//{
		//    return;
		//}
	}


}
