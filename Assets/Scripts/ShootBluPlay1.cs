using UnityEngine;
using System.Collections;

public class ShootBluPlay1 : MonoBehaviour {
	
	public bool isShooting;
	public float timePress;

	public bool force1;
	public bool force2;
	public bool force3;

	public float thrust;
	public float upthrust;
	public float linethrust;

	public Transform shooter;
	public Transform shooter2;

	public bool fill;

	public GameObject balloonBall;

	public bool facingRight;
	public bool facingLeft;

	public bool filledUp;


	// Use this for initialization
	void Start () {
		fill = false;
		filledUp = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<MovBluPlay1> ().isFilled == true) {
			fill = true;
		}





		if (GetComponent<MovBluPlay1> ().faceLeft == true) {
			facingLeft = true;
			facingRight = false;
		}else if (GetComponent<MovBluPlay1> ().faceRight == true) {
			facingRight = true;
			facingLeft = false;
		}



		//======================= SHOOT =======================================================//

		if (GetComponent<MovBluPlay1> ().balloonPop == false && isShooting == true) {

			timePress += 1.7f;
			//GetComponent<Animator> ().SetInteger ("State", 8);
			//print (timePress);
			
			if (timePress < 20) {
				force1 = true;
			} else {
				force1 = false;
			}
			
			if (timePress > 30 && timePress < 60) {
				force2 = true;
			} else {
				force2 = false;
			}
			
			if (timePress > 60) {
				force3 = true;
			} else {
				force3 = false;
			}	

		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp (KeyCode.LeftShift) && isShooting == true) {
			//GetComponent<Animator>().SetInteger("State",0);
			isShooting = false;
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp (KeyCode.LeftShift)) {
			GetComponent<Animator>().SetInteger("State",0);
			timePress = 0;
			fill = false;
			//GetComponent<MovBluPlay1> ().balloonPop = true;
		}


		
		if ((Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.LeftShift)) && fill == true)  {

			isShooting = true;
			fill = false;
			GetComponent<MovBluPlay1> ().balloonPop = false;
			
			if (fill == false){
				GetComponent<MovBluPlay1> ().isFilled = false;
			}

			GetComponent<Animator>().SetInteger("State",8);
			filledUp = true;
			
		} 
		
		// =================================================
		
		if (Input.GetKeyUp (KeyCode.Space) && fill == false) {

			GetComponent<Animator>().SetInteger("State",7);
			
			isShooting = false;
			
			if (force1 == true) {
				linethrust = 5;
			}
			
			if (force2 == true) {
				linethrust = 30;
			}
			
			if (force3 == true) {
				linethrust = 60;
			}
			
			timePress = 0;
			
			if (filledUp == true){

			GameObject myBallon = Instantiate (balloonBall, shooter2.position, shooter2.rotation) as GameObject;
			if (facingRight == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * linethrust + transform.up * 10);
			}
			if (facingLeft == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * linethrust + transform.up * 10);
			}

				filledUp = false;

			}
			
			
		}
		
		
		if (Input.GetKeyUp (KeyCode.LeftShift) && fill == false) {
			
			isShooting = false;
	
			GetComponent<Animator>().SetInteger("State",7);

			if (fill == false){
				GetComponent<MovBluPlay1> ().isFilled = false;
			}

			
			if (force1 == true) {
				upthrust = 10;
				thrust = 5;
			}
			
			if (force2 == true) {
				upthrust = 30;
				thrust = 15;
			}
			
			if (force3 == true) {
				upthrust = 35;
				thrust = 25;
			}
			
			timePress = 0;

			if (filledUp == true){
			
			
			GameObject myBallon = Instantiate (balloonBall, shooter.position, shooter.rotation) as GameObject;
			if (facingRight == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * thrust + transform.up * upthrust);
			}
			if (facingLeft == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * thrust + transform.up * upthrust);
			}
				filledUp = false;
			}
		}
	
	}
	void Throw() {

	}
}
