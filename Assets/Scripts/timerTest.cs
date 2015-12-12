using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerTest : MonoBehaviour {

	public float startTime;
	private float timeLeft;
	Text timer;
	private GameObject bboy, bgirl, rboy, rgirl;
	public GameObject redshirt;
	public GameObject blueshirt;
	public GameObject splash;
	public GameObject screen;
	private GameObject spawner;
	public bool blackscreen = true;

	
	// Use this for initialization
	void Start () {

		timer = GetComponent<Text>();

		bboy = GameObject.Find ("Blue BOY");
		bgirl = GameObject.Find ("Blue GIRL");
		rboy = GameObject.Find ("Red BOY");
		rgirl = GameObject.Find ("Red GIRL");

		spawner = GameObject.Find ("SPAWNER");

		
	}
	
	// Update is called once per frame
	void Update () {

		timeLeft = startTime;

		startTime = startTime - 0.016f;


		//print (timeLeft);
		//timer.text = timeLeft.ToString("#.00");
		timer.text = timeLeft.ToString("#");
		
		if (timeLeft <= 0) {

			rboy.GetComponent<BP1Mov>().done = true;
			rgirl.GetComponent<BP1Mov>().done = true;
			bboy.GetComponent<BP1Mov>().done = true;
			bgirl.GetComponent<BP1Mov>().done = true;

			Camera.main.GetComponent<AudioSource>().volume = 0.12f;

			Destroy (spawner);

			rboy.GetComponent<Animator>().SetInteger ("State",0); 
			rgirl.GetComponent<Animator>().SetInteger ("State",0); 
			bboy.GetComponent<Animator>().SetInteger ("State",0); 
			bgirl.GetComponent<Animator>().SetInteger ("State",0);
		

			rboy.GetComponent<BP1Mov>().enabled = false;
			rgirl.GetComponent<BP1Mov>().enabled = false;
			bboy.GetComponent<BP1Mov>().enabled = false;
			bgirl.GetComponent<BP1Mov>().enabled = false;


			//print ("DONE!");

			if (blackscreen == true){
				blackscreen = false;
				Instantiate(screen, new Vector3 (0,0.65f,-0.5f),transform.rotation);
			}

			blueshirt.GetComponent<shirtScript>().Squish();
			redshirt.GetComponent<shirtScript>().Squish();

			if(redshirt.transform.position.x <= -0.7f){
				redshirt.GetComponent<Animator>().SetInteger ("State",1); 
			}
			if(blueshirt.transform.position.x >= 0.7f){
				blueshirt.GetComponent<Animator>().SetInteger ("State",1); 
			}

			if(blueshirt.transform.position.x <= 0.7f){
			blueshirt.transform.position += new Vector3 (0.06f,-0.02f,0);
			}

			if(redshirt.transform.position.x >= -0.7f){
				redshirt.transform.position += new Vector3 (-0.06f,-0.02f,0);
			}

			timer.text = (" ");


			/*
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
			*/
			
		}
		
	}
	
}
