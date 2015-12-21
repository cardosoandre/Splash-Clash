using UnityEngine;
using System.Collections;

public class BP1Mov : MonoBehaviour {
	
	public float Xspeed, Yspeed, xscale;	
	
	private bool isFilling;
	private bool filledUp;
	private bool holdShot;
	public bool hasBalloon;
	public bool speedUp; //test speed power up
	
	public bool faceRight, faceLeft;

	public bool gotHit = false;

	public float pressTime;
	public float pumpTime = 0;		
	public float upLimit, downLimit, leftLimit, rightLimit;		

	public float fillPitch = 1;

	public GameObject balloonBall;
	public GameObject finishFillSound;

	public Transform UPp, DOWNp;

	public KeyCode keyUP,keyDOWN,keyLEFT,keyRIGHT,keyFILL,keySHOOT;

	public bool canMove = false;
	public bool poisoned = false;
	public bool bubbleshield = false;

	public string tag;

	public Color purple;
	public Color white;

	public bool done = false;

	// Use this for initialization
	void Start () {
		
		xscale = transform.localScale.x;
		hasBalloon = false;
		isFilling = false;
		if(gameObject.CompareTag("Player")){
		faceRight = true;
		}
		if(gameObject.CompareTag("Player 2")){
			faceLeft = true;
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
		}
			
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.G)){
			//Application.LoadLevel("4 player prototype");
		}

		if (canMove) MovPlay ();

		ShootPlay ();

		ChargeShot ();
		
		FixBug ();


		//@@@@@@@@@@ POISON RUN BUG FIX

		// IF POISONED TRUE  =============================
		


	}
	

	//=========TURNON/OFF=====================================================================================

	void TurnCanMoveOn () {
		gotHit = false;
		canMove = true;	
	}

	public void StartPoison() {
		poisoned = true;
		Xspeed = 0.3f;
		Yspeed = 0.8f;
		GetComponent<Animator>().speed = 0.3f;
		GetComponent<SpriteRenderer>().color = purple;
		Invoke ("StopPoison", 10);
	}
	void StopPoison () {
		poisoned = false;
		Xspeed = 1.5f;
		Yspeed = 3;
		GetComponent<Animator>().speed = 1;
		GetComponent<SpriteRenderer> ().color = white;
	}
	
	public void GotHit () {
		if (bubbleshield == false) {
			canMove = false;
			gotHit = true;
		}
		//Invoke ("TurnCanMoveOn", 0.3f);
	}

	public void HasBubble () {
		Invoke ("BubbleOver", 10);
		bubbleshield = true;
		if (gameObject.tag == ("Player")){
		GetComponent<HitMeBlueTeam> ().enabled = false;
		}
		if (gameObject.tag == ("Player 2")){
		GetComponent<HitMeRedTeam> ().enabled = false;
		}
	}

	void BubbleOver () {
		gotHit = false;
		bubbleshield = false;
		if (gameObject.tag == ("Player")) {
			GetComponent<HitMeBlueTeam> ().enabled = true;
		}
		if (gameObject.tag == ("Player 2")) {
			GetComponent<HitMeRedTeam> ().enabled = true;
		}
	}


	//=========MOVE=====================================================================================

	void MovPlay () {

		//RIGHT MOVEMENT (SET TO D)

		if (Input.GetKey (keyRIGHT) && isFilling == false) {

			isFilling = false;

			faceLeft = false;
			faceRight = true;

			if (hasBalloon == false){
			GetComponent<Animator> ().SetInteger ("State", 2);
			}

			if (hasBalloon == true){
			GetComponent<Animator> ().SetInteger ("State", 6);
			} 
		
			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			if (transform.position.x <= rightLimit) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}

			//LEFT MOVEMENT (SET TO A)
			
		} else if (Input.GetKey (keyLEFT) && isFilling == false) {
			
			faceLeft = true;
			faceRight = false;

			if (hasBalloon == false){
				GetComponent<Animator> ().SetInteger ("State", 2);
			}

			if (hasBalloon == true){
				GetComponent<Animator> ().SetInteger ("State", 6);
			}
			
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			if (transform.position.x >= leftLimit) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (isFilling == false && hasBalloon == false) {
			GetComponent<Animator> ().SetInteger ("State", 0);
		} else if (isFilling == false && hasBalloon == true) {
			GetComponent<Animator> ().SetInteger ("State", 5);
		}

		//DOWN MOVEMENT (SET TO S)

		if (Input.GetKey (keyDOWN) && isFilling == false) {

			if (hasBalloon == false){
				GetComponent<Animator> ().SetInteger ("State", 2);
			}

			if (hasBalloon == true){
				GetComponent<Animator> ().SetInteger ("State", 6);
			}

			if (transform.position.z >= downLimit) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		} 

		//UP MOVEMENT (SET TO W)

		if (Input.GetKey (keyUP) && isFilling == false) {

			if (hasBalloon == false) {
				GetComponent<Animator> ().SetInteger ("State", 2);
			}

			if (hasBalloon == true) {
				GetComponent<Animator> ().SetInteger ("State", 6);
			}

			if (transform.position.z <= upLimit) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}

	} //VOID FINISH

	//=========CHARGE=====================================================================================
		
	void ChargeShot () {

		//SLOW DOWN CHARGE
		
		if (Input.GetKey (keySHOOT) && isFilling == false && hasBalloon == true) {

			if (Input.GetKeyDown (keyFILL) == false){ //@@@@

			pressTime = pressTime + 1.5f;
			//print(pressTime);
	
			if (poisoned == false){
			Xspeed = 0.5f; 
			Yspeed = 1;
			}


			if (pressTime >= 80){
				pressTime = 80;
			}

			}//@@@@

			if(Input.GetKey(keyUP) == false && Input.GetKey(keyDOWN) == false && Input.GetKey(keyLEFT) == false && Input.GetKey(keyRIGHT) == false
			   && Input.GetKeyDown(keyFILL) == false){
			GetComponent<Animator> ().SetInteger ("State", 8);
			}

			if(Input.GetKey(keyUP) == true || Input.GetKey(keyDOWN) == true || Input.GetKey(keyLEFT) == true || Input.GetKey(keyRIGHT) == true
			   && Input.GetKeyDown(keyFILL) == false){
				GetComponent<Animator> ().SetInteger ("State", 13);
			}
			
			
		} else if (Input.GetKeyUp (keySHOOT) && isFilling == false) {
			pressTime = 0;
			if (poisoned == false){
			Xspeed = 1.5f;
			Yspeed = 3;
			}
			hasBalloon = false;
			GetComponent<Animator> ().SetInteger ("State", 7);
		}

		if (Input.GetKey(keyFILL) && hasBalloon == false && isFilling == true) {
			GetComponent<Animator> ().SetInteger ("State", 12);
			isFilling = false;
		}

		// GOTHIT STATE  ===== REMEMBER THIS !!!!! ======

		if (gotHit == true && bubbleshield == false) {

			GetComponent<Animator> ().SetInteger ("State", 10);
			canMove = false;
			Invoke("TurnCanMoveOn",0.25f);
			gotHit = false;


		}

	}

	// /*

//==== TEMPORARY TEST @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

	void OnTriggerStay(Collider other){

		//Use this for when the fill is ready = hasBalloon; 


		if (Input.GetKey(keyRIGHT) == false && Input.GetKey(keyLEFT) == false){

		if (other.tag == ("Pump") && done == false && hasBalloon == false) {

			other.SendMessage ("Key", keyFILL);
			other.SendMessage ("Key2", keySHOOT);

			if (gameObject.tag == ("Player") && faceRight == false) {
				other.SendMessage ("OnArea");
			}

			if (gameObject.tag == ("Player 2") && faceLeft == false) {	
				other.SendMessage ("OnArea");
			}

			if (isFilling == true) {
				hasBalloon = false;
			}

			if (Input.GetKeyDown (keyFILL) && Input.GetKey (keyLEFT) == false && Input.GetKey (keyRIGHT) == false
				&& Input.GetKey (keySHOOT) == false && hasBalloon == false) {

				if (gameObject.tag == ("Player") && faceLeft == true) {
					transform.position = other.transform.position + new Vector3 (0.185f, 0.146f, -0.146f);
					isFilling = true;
					if (other.GetComponent<pumpScript> ().fill >= 9) {
						other.GetComponent<Animator> ().SetInteger ("State", 0);
						hasBalloon = true;
						Instantiate (finishFillSound, transform.position, transform.rotation);
						isFilling = false;
						pumpTime = 0;
					}
				}
				if (gameObject.tag == ("Player 2") && faceRight == true) {
					transform.position = other.transform.position + new Vector3 (-0.185f, 0.146f, -0.146f);
					isFilling = true;
					if (other.GetComponent<pumpScript> ().fill >= 9) {
						other.GetComponent<Animator> ().SetInteger ("State", 0);
						hasBalloon = true;
						Instantiate (finishFillSound, transform.position, transform.rotation);
						isFilling = false;
						pumpTime = 0;
					}
				}
			}
		}

	}
	
		}

	void OnTriggerExit(Collider other){
		if (other.tag == ("Pump")) {
			if (hasBalloon == true){
				pumpTime = 0;
			}
			other.SendMessage ("ExitArea");
		}
	}

	//  */

	/*
	//=========PUMP=====================================================================================
	
	void OnTriggerStay(Collider other){
		
		if (other.CompareTag ("Pump") && hasBalloon == false) {
			isFilling = false;
			//print (pumpTime);

			if (pumpTime < 1){
				other.GetComponent<Animator> ().SetInteger ("State", 0);
			}

			if (pumpTime >= 10) {
				other.GetComponent<Animator> ().SetInteger ("State", 0);
				GetComponent<Animator> ().SetInteger ("State", 5);
				//print("FILLED GO GO!");
				hasBalloon = true;
				isFilling = false;
				pumpTime = 0;
				fillPitch = 1;
				Instantiate (finishFillSound, transform.position, transform.rotation);
			}
			if (Input.GetKeyDown (keyFILL) && Input.GetKey (keySHOOT) == false) {
				other.GetComponent<AudioSource> ().Play ();
				other.GetComponent<AudioSource> ().pitch = fillPitch;
				fillPitch = fillPitch + 0.2f;
				pumpTime = pumpTime + 1;
				isFilling = true;
			} 

			if (Input.GetKey (keyFILL) && hasBalloon == false && isFilling == true) {
				if (pumpTime < 2){
				other.GetComponent<Animator> ().SetInteger ("State", 1);
				}
				if (pumpTime > 2 && pumpTime < 4){
					other.GetComponent<Animator> ().SetInteger ("State", 2);
				}
				if (pumpTime > 4 && pumpTime <= 6){
					other.GetComponent<Animator> ().SetInteger ("State", 3);
				}
				if (pumpTime > 6 && pumpTime <= 8){
					other.GetComponent<Animator> ().SetInteger ("State", 4);
				}
			}

		}

	
	}// ONTRIGGER FINISH

	void OnTriggerExit (Collider other){
		if (other.CompareTag ("Pump")) {
			fillPitch = 1;
			pumpTime = pumpTime;
			//isFilling = false;
			if (hasBalloon == true){
				pumpTime = 0;
				isFilling = false;
			}
		}
	}// ONTRIGGER FINISH

*/


	// GOTHIT STATE  ===== REMEMBER THIS !!!!! ======

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == tag) {

			gotHit = true;

		}

	}

	
	//ONTRIGGERFINISH



	//=========SHOOT=====================================================================================


	void ShootPlay () {


		if (Input.GetKeyUp (keySHOOT) && hasBalloon == true && Input.GetKey (keyFILL) == false
		    && isFilling == false) {

			GetComponent<AudioSource>().Play();

			GameObject myBallon = Instantiate (balloonBall, UPp.position, UPp.rotation) as GameObject;
			myBallon.GetComponent<whoDidIt>().playerName = gameObject.name;
			if (faceRight == true) {
				myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * pressTime + transform.up * 10);
			}
			if (faceLeft == true) {
				myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * pressTime + transform.up * 10);
			}
		}

			if (Input.GetKeyUp (keySHOOT) && Input.GetKey (keyFILL) && hasBalloon == true
		    && isFilling == false) {

			GetComponent<AudioSource>().Play();
			
			GameObject myBallon = Instantiate (balloonBall, UPp.position, UPp.rotation) as GameObject;
			if (faceRight == true) {
				myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * pressTime/3.2f + transform.up * 40);
			}
			if (faceLeft == true) {
				myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * pressTime/3.2f + transform.up * 40);
			}
		
		}


	} // VOID FINISH

	//=========DEBUG=====================================================================================

	void FixBug(){

		if (Input.GetKey (keyRIGHT) ||
		    Input.GetKey (keyLEFT) ||
		    Input.GetKey (keyUP) ||
		    Input.GetKey (keyDOWN) 
		    && isFilling == true) {
			
			isFilling = false;
			
		}

	}
		

		
	}