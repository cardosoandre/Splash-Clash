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
	
	public float pumpTime = 0;		
	public float upLimit;		
	public float downLimit;		
	public float leftLimit;		
	public float rightLimit;	
	
	
	// Use this for initialization
	void Start () {
		
		xscale = transform.localScale.x;
		hasBalloon = false;
		isFilling = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		NoBalloonMov ();

	}

	void NoBalloonMov () {

		//RIGHT MOVEMENT (SET TO D)

		if (Input.GetKey (KeyCode.D) && isFilling == false) {
			
			faceLeft = false;
			faceRight = true;

			//GetComponent<Animator>().SetInteger("State", 2);

			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			if (transform.position.x <= rightLimit) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}

		//LEFT MOVEMENT (SET TO A)
			
		} else if (Input.GetKey (KeyCode.A) && isFilling == false) {
			
			faceLeft = true;
			faceRight = false;
			
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			if (transform.position.x >= leftLimit) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		}

		//DOWN MOVEMENT (SET TO S)

		if (Input.GetKey (KeyCode.S) && isFilling == false) {
			if (transform.position.z >= downLimit) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		}

		//UP MOVEMENT (SET TO W)

		if (Input.GetKey (KeyCode.W) && isFilling == false) {
			if (transform.position.z <= upLimit) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}

		if (Input.GetKeyDown (KeyCode.Space) && hasBalloon == true) {
			Xspeed = 0.3f;
			Yspeed = 1;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			hasBalloon = false;
			Xspeed = 1.5f;
			Yspeed = 3;
		}


	} //VOID FINISH


	//=========PUMP AREA================================================

	void OnTriggerStay(Collider other){
		
		if (other.CompareTag ("Pump")) {
			print (pumpTime);
			if(pumpTime >= 8){
				print("FILLED GO GO!");
				hasBalloon = true;
				filledUp = true;
			}
			if (Input.GetKeyUp (KeyCode.F)) {
				isFilling = true;
				pumpTime = pumpTime + 1;
			} else {
				isFilling = false;
			}
		}
	}// ONTRIGGER FINISH

	void OnTriggerExit (Collider other){
		if (other.CompareTag ("Pump")) {
			pumpTime = 0;
			print(pumpTime);
		}
	}
}