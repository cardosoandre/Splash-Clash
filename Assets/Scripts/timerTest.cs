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

			if(RedPlayer.GetComponent<hitRedPlayer>().bluescore > BluePlayer.GetComponent<hitBluePlayer>().redscore){
				Application.LoadLevel("Blue Team Wins");
			} 

			if(RedPlayer.GetComponent<hitRedPlayer>().bluescore < BluePlayer.GetComponent<hitBluePlayer>().redscore){
				Application.LoadLevel("Red Team Wins");
			} 

			if(RedPlayer.GetComponent<hitRedPlayer>().bluescore == BluePlayer.GetComponent<hitBluePlayer>().redscore){
				Application.LoadLevel("Draw Scene");
			}
			
		}
		
	}
}
