using UnityEngine;
using System.Collections;

public class HitMeRedTeam : MonoBehaviour {

	public int bluescore;

	// Use this for initialization
	void Start () {

		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "BlueBalloon") { //balloon can be changed to specifc color tag
			//bluescore = bluescore + 1; 
			//Debug.Log ("Blue Score = " + bluescore);
			
		}
	}

	void getWet(float waterScore){
		//print (waterAmount + "omg actually worked" );
		bluescore = bluescore + (int) waterScore;
		print ("BLUE SCORE IS: " + bluescore);
	}
}
