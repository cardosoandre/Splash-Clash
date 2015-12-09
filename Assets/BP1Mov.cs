using UnityEngine;
using System.Collections;

public class BP1Mov : MonoBehaviour {
	
	public float Xspeed, Yspeed, xscale;	
	
	private bool isFilling;
	private bool filledUp;
	private bool holdShot;
	public bool hasBalloon;
	public bool speedUp; //test speed power up
	
	private bool faceRight, faceLeft;

	public bool gotHit = false;

	public float pressTime;
	public float pumpTime = 0;		
	public float upLimit, downLimit, leftLimit, rightLimit;		

	public float fillPitch = 1;
	public float speedUpTimer; //add timer amount?
	public float speedUpMultiplyer = 1; //add f? Default unmodified speed, changes during powerUp

	public GameObject balloonBall;
	public GameObject finishFillSound;

	public Transform UPp, DOWNp;

	public KeyCode keyUP,keyDOWN,keyLEFT,keyRIGHT,keyFILL,keySHOOT;

	public bool canMove = true;

	public string tag;

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
			Application.LoadLevel("4 player prototype");
		}

		if (canMove) MovPlay ();
		ShootPlay ();
		ChargeShot ();
		FixBug ();

		if (speedUp = true) speedUpCountDown (); //added to control speedUp timer
	

	}

	//=========TURNON/OFF=====================================================================================

	void TurnCanMoveOn () {
		gotHit = false;
		canMove = true;	
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
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime * speedUpMultiplyer);
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
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime * speedUpMultiplyer);
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
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime * speedUpMultiplyer);
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
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime * speedUpMultiplyer);
			}
		}

	} //VOID FINISH

	//=========CHARGE=====================================================================================
	
	void ChargeShot () {

		//SLOW DOWN CHARGE
		
		if (Input.GetKey (keySHOOT) && isFilling == false && hasBalloon == true) {
			pressTime = pressTime + 1.5f;
			//print(pressTime);
			Xspeed = 0.5f * speedUpMultiplyer;
			Yspeed = 1 * speedUpMultiplyer;

			if (pressTime >= 80){
				pressTime = 80;
			}

			if(Input.GetKey(keyUP) == false && Input.GetKey(keyDOWN) == false && Input.GetKey(keyLEFT) == false && Input.GetKey(keyRIGHT) == false){
			GetComponent<Animator> ().SetInteger ("State", 8);
			}

			if(Input.GetKey(keyUP) == true || Input.GetKey(keyDOWN) == true || Input.GetKey(keyLEFT) == true || Input.GetKey(keyRIGHT) == true){
				GetComponent<Animator> ().SetInteger ("State", 13);
			}
			
			
		} else if (Input.GetKeyUp (keySHOOT) && isFilling == false) {
			pressTime = 0;
			Xspeed = 1.5f * speedUpMultiplyer;
			Yspeed = 3 * speedUpMultiplyer;
			hasBalloon = false;
			GetComponent<Animator> ().SetInteger ("State", 7);
		}

		if (Input.GetKey(keyFILL) && hasBalloon == false && isFilling == true) {
			GetComponent<Animator> ().SetInteger ("State", 12);
			isFilling = false;
		}

		// GOTHIT STATE  ===== REMEMBER THIS !!!!! ======

		if (gotHit == true) {

			GetComponent<Animator> ().SetInteger ("State", 10);
			canMove = false;
			Invoke("TurnCanMoveOn",0.2f);
			gotHit = false;


		}
	}


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


	// GOTHIT STATE  ===== REMEMBER THIS !!!!! ======

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == tag ) {

			gotHit = true;

   // SPEED POWER UP  ===== 
			
			//test speed power up; button to pick up power ups? CHANGE TO ON TRIGGER ENTER
			
			if (other.CompareTag ("speedPowerUp") && hasBalloon == false) { //def. no balloon only?
				speedUp = true;
				speedUpMultiplyer = 0.3f; //power changed to SLOW DOWN - test speeds
				speedUpTimer = 5; //seconds


				//may need to add check when timer is expires to reset speed to *1
			}

		}
	}

	void speedUpCountDown(){ //TO DO: CONFIRM THIS COUNTS DOWN
		if (speedUpTimer > 0) {
			speedUpTimer -= Time.deltaTime;
		} else {
			speedUp = false;
			speedUpMultiplyer = 1; //test speeds
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