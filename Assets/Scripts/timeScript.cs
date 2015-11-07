using UnityEngine;
using System.Collections;
public class timeScript : MonoBehaviour {

	public float timeLeft = 60;


	// Use this for initialization
	void Start () {

		timeLeft = 60;

	}
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;
		//print (timeLeft);
		if (timeLeft <= -60) {
			print ("DONE!");

		}
	
	}
}
