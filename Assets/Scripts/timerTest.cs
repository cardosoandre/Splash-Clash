using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerTest : MonoBehaviour {

	public float startTime = 60;
	private float timeLeft;
	Text timer;
	public GameObject BluePlayer;
	public GameObject RedPlayer;
	public GameObject BluePlayer2;
	public GameObject RedPlayer2;
	
	// Use this for initialization
	void Start () {

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
