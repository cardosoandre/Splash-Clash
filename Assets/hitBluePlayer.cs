using UnityEngine;
using System.Collections;

public class hitBluePlayer : MonoBehaviour {

	public int redscore;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "RedBalloon") { //balloon can be changed to specifc color tag
			redscore = redscore + 1; 
			Debug.Log ("Red Score = " + redscore);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
