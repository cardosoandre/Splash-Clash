﻿using UnityEngine;
using System.Collections;

public class MovePlayerTestFill : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public bool facingRight;
	public bool facingLeft;
	public GameObject balloonBall;
	public Transform shooter;
	public Transform shooter2;
	public float thrust;
	public float upthrust;
	public float linethrust;
	public float timePress;
	public bool isFilled;
	
	private GameObject indicator;
	
	private bool isShooting = false;
	
	public bool force1;
	public bool force2;
	public bool force3;
	
	
	// Use this for initialization
	void Start () {
		
		facingRight = true;
		timePress = 0;
		indicator = GameObject.Find ("ForceText");
		isFilled = false;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//======================= MOVEMENT =======================================================//
		
		
		if (Input.GetKey (KeyCode.A) && isShooting == false) {
			
			
			facingLeft = true;
			facingRight = false;
			
			GetComponent<Animator>().SetInteger("State",2);
			if (transform.position.x >= -1.2f) {
				transform.Translate (-Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.D) && isShooting == false) {
			
			facingRight = true;
			facingLeft = false;
			
			GetComponent<Animator>().SetInteger("State",1);
			if (transform.position.x <= -0.114f) {
				transform.Translate (Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.S) && isShooting == false) {
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.W) && isShooting == false) {
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}
		
		
		//======================= SHOOT =======================================================//
		
		
		if ((Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.LeftShift)) && isFilled == true)  {
			
			isShooting = true;
			
			timePress += 1;
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
		
		//INDICATOR DEBUG ==================================
		
		if (force1 == true) {
			indicator.GetComponent<TextMesh> ().text = ("1");
		}
		
		if (force2 == true) {
			indicator.GetComponent<TextMesh> ().text = ("2");
		}
		
		if (force3 == true) {
			indicator.GetComponent<TextMesh> ().text = ("3");
		}
		
		// =================================================
		
		if (Input.GetKeyUp (KeyCode.Space)) {
			
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
			
			
			
			GameObject myBallon = Instantiate (balloonBall, shooter2.position, shooter2.rotation) as GameObject;
			if (facingRight == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * linethrust + transform.up * 10);
			}
			if (facingLeft == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * linethrust + transform.up * 10);
			}
			
		}
		
		
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			
			isShooting = false;
			
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
			
			
			GameObject myBallon = Instantiate (balloonBall, shooter.position, shooter.rotation) as GameObject;
			if (facingRight == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * thrust + transform.up * upthrust);
			}
			if (facingLeft == true){
				myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * thrust + transform.up * upthrust);
			}
		}
	}
	void OnTriggerStay(Collider other){
		if (other.CompareTag("Pump") && Input.GetKey (KeyCode.F) == true) {
			isFilled = true;
			Debug.Log ("Filled? " + isFilled);
		}
	}
}