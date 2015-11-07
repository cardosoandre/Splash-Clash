using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerTest : MonoBehaviour {

	public float startTime = 60;
	private float timeLeft;
	Text timer;

	
	
	// Use this for initialization
	void Start () {
		
		startTime = 5;
		timer = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timeLeft =  startTime - Time.time ;
		//print (timeLeft);
		//timer.text = timeLeft.ToString("#.00");
		timer.text = timeLeft.ToString("#.00");
		
		if (timeLeft <= 0) {
			print ("DONE!");
			timer.text = ("TIME!");
			
		}
		
	}
}
