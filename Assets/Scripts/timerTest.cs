using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerTest : MonoBehaviour {

	public float startTime = 60;
	private float timeLeft;
	Text timer;
	private GameObject BluePlayer;
	private GameObject RedPlayer;
	private GameObject BluePlayer2;
	private GameObject RedPlayer2;
	
	// Use this for initialization
	void Start () {


		BluePlayer = GameObject.Find ("Blue Play 1");
		RedPlayer = GameObject.Find ("Red Play 2");
		BluePlayer2 = GameObject.Find ("Blue Play 3");
		RedPlayer2 = GameObject.Find ("Red Play 4");



		startTime = 80;
		timer = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timeLeft = startTime;

		startTime = startTime - 0.016f;


		//print (timeLeft);
		//timer.text = timeLeft.ToString("#.00");
		timer.text = timeLeft.ToString("#");
		
		if (timeLeft <= 0) {
			print ("DONE!");

			timer.text = ("TIME!");

			if(RedPlayer.GetComponent<HitMeRedTeam>().bluescore + 
			   RedPlayer2.GetComponent<HitMeRedTeam>().bluescore >
			   BluePlayer.GetComponent<HitMeBlueTeam>().redscore +
			   BluePlayer2.GetComponent<HitMeBlueTeam>().redscore) {
				Application.LoadLevel("Blue Team Wins");
			} 

			if(RedPlayer.GetComponent<HitMeRedTeam>().bluescore + 
			   RedPlayer2.GetComponent<HitMeRedTeam>().bluescore <
			   BluePlayer.GetComponent<HitMeBlueTeam>().redscore +
			   BluePlayer2.GetComponent<HitMeBlueTeam>().redscore) {
				Application.LoadLevel("Red Team Wins");
			} 

			if(RedPlayer.GetComponent<HitMeRedTeam>().bluescore + 
			   RedPlayer2.GetComponent<HitMeRedTeam>().bluescore ==
			   BluePlayer.GetComponent<HitMeBlueTeam>().redscore +
			   BluePlayer2.GetComponent<HitMeBlueTeam>().redscore) {
				Application.LoadLevel("Draw Scene");
			}
			
		}
		
	}
}
