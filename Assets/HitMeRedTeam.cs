using UnityEngine;
using System.Collections;

public class HitMeRedTeam : MonoBehaviour {

	public int bluescore;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "RedBalloon") { //balloon can be changed to specifc color tag
			bluescore = bluescore + 1; 
			Debug.Log ("Blue Score = " + bluescore);
			
		}
	}
}
