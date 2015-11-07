using UnityEngine;
using System.Collections;

public class PlayerWaterLevel : MonoBehaviour {
	public int score;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "BlueBalloon") { //balloon can be changed to specifc color tag
			score = score + 1; 
			Debug.Log ("Score = " + score);
	
		}
	}

		void Update (){

		}
}
