using UnityEngine;
using System.Collections;

public class PlayerWaterLevel : MonoBehaviour {
	public int bluescore;
	public int redscore;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "BlueBalloon") { //balloon can be changed to specifc color tag
			bluescore = bluescore + 1; 
			Debug.Log ("Blue Score = " + bluescore);
	
		}

		if (other.tag == "RedBalloon") { //balloon can be changed to specifc color tag
			redscore = redscore + 1; 
			Debug.Log ("Red Score = " + redscore);
			
		}


	}

		void Update (){

		}
}
