using UnityEngine;
using System.Collections;

public class BP1Mov : MonoBehaviour {
	
	public float Xspeed;	
	public float Yspeed;
	private float xscale;
	
	private bool isFilling;
	private bool filledUp;
	private bool holdShot;
	private bool hasBalloon;
	
	public bool faceRight;
	public bool faceLeft;

	public bool gotHit = false;

	public float pressTime;
	public float pumpTime = 0;		
	public float upLimit;		
	public float downLimit;		
	public float leftLimit;		
	public float rightLimit;	
	public float fillPitch = 1;

	public GameObject balloonBall;

	public Transform UPp;
	public Transform DOWNp;

	public KeyCode keyUP;
	public KeyCode keyDOWN;
	public KeyCode keyLEFT;
	public KeyCode keyRIGHT;
	public KeyCode keyFILL;
	public KeyCode keySHOOT;

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
			Application.LoadLevel("2 player prototype");
		}

		MovPlay ();
		ShootPlay ();
		ChargeShot ();
		FixBug ();

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
			pressTime = pressTime + 1.5f;
			print(pressTime);
			Xspeed = 0.5f;
			Yspeed = 1;

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
			Xspeed = 1.5f;
			Yspeed = 3;
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
			gotHit = false;

		}
	}


	//=========PUMP=====================================================================================
	
	void OnTriggerStay(Collider other){
		
		if (other.CompareTag ("Pump") && hasBalloon == false) {
			isFilling = false;
			print (pumpTime);
			if(pumpTime >= 16){
				other.GetComponent<Animator> ().SetInteger ("State", 0);
				GetComponent<Animator> ().SetInteger ("State", 5);
				print("FILLED GO GO!");
				hasBalloon = true;
				isFilling = false;
				pumpTime = 0;
				fillPitch = 1;
			}
			if (Input.GetKeyDown (keyFILL)) {
				other.GetComponent<AudioSource> ().Play ();
				other.GetComponent<AudioSource> ().pitch = fillPitch;
				fillPitch = fillPitch + 0.2f;
				pumpTime = pumpTime + 1;
				isFilling = true;
			} 

			if (Input.GetKey(keyFILL) && hasBalloon == false && isFilling == true) {
				other.GetComponent<Animator> ().SetInteger ("State", 1);
			}

		}
	}// ONTRIGGER FINISH

	void OnTriggerExit (Collider other){
		if (other.CompareTag ("Pump")) {
			fillPitch = 1;
			pumpTime = 0;
			isFilling = false;
			//print(pumpTime);
		}
	}// ONTRIGGER FINISH


	// GOTHIT STATE  ===== REMEMBER THIS !!!!! ======

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "RedBalloon") {

			gotHit = true;

		}
	}

	//ONTRIGGERFINISH



	//=========SHOOT=====================================================================================


	void ShootPlay () {


		if (Input.GetKeyUp (keySHOOT) && hasBalloon == true && Input.GetKey (keyFILL) == false
		    && isFilling == false) {

			GameObject myBallon = Instantiate (balloonBall, UPp.position, UPp.rotation) as GameObject;
			if (faceRight == true) {
				myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * pressTime + transform.up * 10);
			}
			if (faceLeft == true) {
				myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * pressTime + transform.up * 10);
			}
		}

			if (Input.GetKeyUp (keySHOOT) && Input.GetKey (keyFILL) && hasBalloon == true
		    && isFilling == false) {
			
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