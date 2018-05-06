using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBlock : MonoBehaviour {

	public int xPos;
	public int yPos;

	// Use this for initialization
	void Start () {
		xPos = (int) transform.position.x;
		yPos = (int) transform.position.y;
	}
	/*
	int getX(){
		return xPos;
	}

	int getY(){
		return yPos;
	}*/
	// Update is called once per frame
	void Update () {
		
	}
}
