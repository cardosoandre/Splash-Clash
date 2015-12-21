using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerTest : MonoBehaviour {

	public float startTime;
	private float timeLeft;
	Text timer;
	private GameObject bboy, bgirl, rboy, rgirl;
	public GameObject whistle;
	public GameObject redshirt;
	public GameObject blueshirt;
	public GameObject splash;
	public GameObject screen;
	private GameObject spawner;
	public bool blackscreen = true;
	public bool paused = false;
	public bool done = false;
	public bool start = false;
	public GameObject donesprite;

	// Use this for initialization
	void Start () {


		Invoke ("StartGame", 3);

		
		timer = GetComponent<Text>();

		bboy = GameObject.Find ("Blue BOY");
		bgirl = GameObject.Find ("Blue GIRL");
		rboy = GameObject.Find ("Red BOY");
		rgirl = GameObject.Find ("Red GIRL");
		spawner = GameObject.Find ("@SPAWNER");

		
		
	}
	
	// Update is called once per frame
	void Update () {


		if (start == true) { // <=============== remember!

			timeLeft = startTime;

			if (paused == false) {
				startTime = startTime - 0.016f;
			}


			//print (timeLeft);
			//timer.text = timeLeft.ToString("#.00");
			timer.text = timeLeft.ToString ("#");
		
			if (timeLeft <= 0) {

				done = true;

				rboy.GetComponent<BP1Mov> ().done = true;
				rgirl.GetComponent<BP1Mov> ().done = true;
				bboy.GetComponent<BP1Mov> ().done = true;
				bgirl.GetComponent<BP1Mov> ().done = true;

				Camera.main.GetComponent<AudioSource> ().Stop();

				Destroy (spawner);

				rboy.GetComponent<Animator> ().SetInteger ("State", 0); 
				rgirl.GetComponent<Animator> ().SetInteger ("State", 0); 
				bboy.GetComponent<Animator> ().SetInteger ("State", 0); 
				bgirl.GetComponent<Animator> ().SetInteger ("State", 0);
		

				rboy.GetComponent<BP1Mov> ().enabled = false;
				rgirl.GetComponent<BP1Mov> ().enabled = false;
				bboy.GetComponent<BP1Mov> ().enabled = false;
				bgirl.GetComponent<BP1Mov> ().enabled = false;


				//print ("DONE!");

				if (blackscreen == true) {

					Instantiate (whistle, transform.position, transform.rotation);
					Instantiate (donesprite, new Vector3 (0,0.6f,0), transform.rotation);
					blackscreen = false;
					//Instantiate (screen, new Vector3 (0, 0.65f, -0.5f), transform.rotation);
					Invoke ("BlackS",3);
				}


				// find all powerups and destroy them when the time is over

				GameObject[] powU = GameObject.FindGameObjectsWithTag ("PowerUp");

				foreach (GameObject p in powU) {
					Destroy (p);
				}

				//enable the squish
				Invoke ("EnableSquish", 4f);
				//show players
				Invoke ("Players", 4f);

				Invoke ("MoveShirts",3);

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
		} // <========= this is where the if start false ends
		
	}

	void BlackS() {
		Instantiate (screen, new Vector3 (0, 0.65f, -0.6f), transform.rotation);
	}

	void MoveShirts() {
		
		if (redshirt.transform.position.x <= -0.7f) {
			//redshirt.GetComponent<Animator>().SetInteger ("State",1); 
		}
		if (blueshirt.transform.position.x >= 0.7f) {
			//blueshirt.GetComponent<Animator>().SetInteger ("State",1); 
		}
		
		if (blueshirt.transform.position.x <= 0.7f) {
			blueshirt.transform.position += new Vector3 (0.06f, -0.02f, 0);
		}
		
		if (redshirt.transform.position.x >= -0.7f) {
			redshirt.transform.position += new Vector3 (-0.06f, -0.02f, 0);
		}
	}
	
	void EnableSquish () {
		blueshirt.GetComponent<shirtScript> ().Squish ();
		redshirt.GetComponent<shirtScript> ().Squish ();
	}

	void Players () {
		//blueshirt.GetComponent<Animator> ().SetInteger ("State",1); 
		//redshirt.GetComponent<Animator> ().SetInteger ("State",1); 
		//blueshirt.GetComponent<Animator> ().SetInteger ("State",1); 
		//redshirt.GetComponent<Animator> ().SetInteger ("State",1); 


		GameObject.Find ("BlueBoyHold").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find ("BlueBoyHold").GetComponent<FinalSquish> ().enabled = true;
		GameObject.Find ("BlueGirlHold").GetComponent<FinalSquish> ().enabled = true;
		GameObject.Find ("BlueGirlHold").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find ("RedBoyHold").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find ("RedBoyHold").GetComponent<FinalSquish> ().enabled = true;
		GameObject.Find ("RedGirlHold").GetComponent<FinalSquish> ().enabled = true;
		GameObject.Find ("RedGirlHold").GetComponent<SpriteRenderer> ().enabled = true;
	}

	void StartGame (){
		start = true;
		Camera.main.GetComponent<AudioSource> ().Play ();

		bboy.GetComponent<BP1Mov> ().canMove = true;
		bgirl.GetComponent<BP1Mov> ().canMove = true;
		rboy.GetComponent<BP1Mov> ().canMove = true;
		rgirl.GetComponent<BP1Mov> ().canMove = true;
		spawner.GetComponent<randBalloonGen> ().enabled = true;

	}
	
}
