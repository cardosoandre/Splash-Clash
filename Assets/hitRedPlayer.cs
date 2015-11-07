using UnityEngine;
using System.Collections;

public class hitRedPlayer : MonoBehaviour {

	public int bluescore;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "BlueBalloon") { //balloon can be changed to specifc color tag
			bluescore = bluescore + 1; 
			Debug.Log ("Blue Score = " + bluescore);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
