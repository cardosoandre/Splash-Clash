﻿using UnityEngine;
using System.Collections;

public class randBalloonGen : MonoBehaviour {

	public GameObject bubblePowerUp;
	public GameObject poisonPowerUp;
	public GameObject bombPowerUp;
	public GameObject bubblepreview, poisonpreview, bombpreview;

	public float minTime; //min time between power up appearance
	public float maxTime; //max time between power up appearance

	private float pos;
	private float pos2;
	private float pos3;
	
	void Start(){

		pos = Random.Range (-0.6f, 2.1f);
		pos2 = Random.Range (-0.6f, 2.1f);
		pos3 = Random.Range (-0.6f, 2.1f);

		float time1 = Random.Range (5, 10);
		float time2 = Random.Range (10, 20);
		float time3 = Random.Range (30, 35);

		Invoke ("SpawnBubble", time1);
		Invoke ("SpawnPoison", time2);
		Invoke ("SpawnBomb", time3);


	}

	void SpawnBubble(){
		Vector3 position = new Vector3 (0, -0.125f, pos);
		Instantiate (bubblepreview, position, Quaternion.identity);
		Invoke ("SpawnBubble2", 1.5f);

	}

	void SpawnBubble2(){
		Vector3 position = new Vector3 (0, 0, pos);
		Instantiate (bubblePowerUp, position, Quaternion.identity);
		float time1 = Random.Range (25, 30);
		Invoke ("SpawnBubble", time1);
	}

	void SpawnPoison(){
		Vector3 position = new Vector3 (0, -0.125f, pos2);
		Instantiate (poisonpreview, position, Quaternion.identity);
		Invoke ("SpawnPoison2", 1.5f);
		
	}
	
	void SpawnPoison2(){
		Vector3 position =  new Vector3(0,0,pos2);
		Instantiate (poisonPowerUp, position, Quaternion.identity);
		float time2 = Random.Range (30, 35);
		Invoke ("SpawnPoison", time2);
	}

	void SpawnBomb(){
		Vector3 position = new Vector3 (0, -0.125f, pos3);
		Instantiate (bombpreview, position, Quaternion.identity);
		Invoke ("SpawnBomb2", 1.5f);
		
	}

	void SpawnBomb2(){
		Vector3 position =  new Vector3(0,0,pos3);
		Instantiate (bombPowerUp, position, Quaternion.identity);
		float time3 = Random.Range (30, 35);
		Invoke("SpawnBomb", time3);
	}
}