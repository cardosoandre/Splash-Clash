using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerTest : MonoBehaviour {

	public float startTime = 60;
	private float timeLeft;
	Text timer;
	public GameObject BluePlayer;
	public GameObject RedPlayer;

	
	
	// Use this for initialization
	void Start () {


		BluePlayer = GameObject.Find ("Player Boy");
		RedPlayer = GameObject.Find ("Player Girl");


		startTime = 10;
		timer = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timeLeft =  startTime - Time.time ;
		//print (timeLeft);
		//timer.text = timeLeft.ToString("#.00");
		timer.text = timeLeft.ToString("#");
		
		if (timeLeft <= 0) {
			print ("DONE!");

			timer.text = ("TIME!");

			if(RedPlayer.GetComponent<hitRedPlayer>().bluescore > BluePlayer.GetComponent<hitBluePlayer>().redscore){
				print("BLUE TEAM WON");
			}

			if(RedPlayer.GetComponent<hitRedPlayer>().bluescore < BluePlayer.GetComponent<hitBluePlayer>().redscore){
				print("RED TEAM WON");
			}
		
			
		}
		
	}
}
