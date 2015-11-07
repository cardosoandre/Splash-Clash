using UnityEngine;
using System.Collections;

public class PlayerWaterLevel : MonoBehaviour {
	public int score;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Balloon") { //balloon can be changed to specifc color tag
			score = score + 1; 
			Debug.Log ("Object destroyed = " + (other.gameObject));
	
		}
	}

		void Update (){
		Debug.Log ("Score = " + score);

		}
}
