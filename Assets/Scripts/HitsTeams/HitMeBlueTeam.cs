﻿using UnityEngine;
using System.Collections;

public class HitMeBlueTeam : MonoBehaviour {

	public int redscore;
	
	// Use this for initialization
	void Start () {
		
	}

	void Update (){


	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "RedBalloon") { //balloon can be changed to specifc color tag
			//redscore = redscore + 1; 
			//Debug.Log ("Red Score = " + redscore);
			
		}
	}

	void getWet(float waterScore){
		//print (waterAmount + "omg actually worked" );
		if (GetComponent<BP1Mov> ().bubbleshield == false) {
			redscore = redscore + (int)waterScore;
		}
		print ("RED SCORE IS: " + redscore);
	}
}

