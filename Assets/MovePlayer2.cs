using UnityEngine;
using System.Collections;

public class MovePlayer2 : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	//public bool facingRight;
	//public bool facingLeft;
	public GameObject balloonBall;
	public Transform shooter;
	public Transform shooter2;
	public float thrust;
	public float upthrust;
	public float linethrust;
	public float timePress;
	
	//private GameObject indicator;
	
	private bool isShooting = false;
	
	
	public bool force1;
	public bool force2;
	public bool force3;

	// Use this for initialization
	void Start () {

	timePress = 0;
		
	}

	//======================= MOVEMENT =======================================================/
	
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow) && isShooting == false) {
			if (transform.position.x >= 0.114f) {
				transform.Translate (-Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.RightArrow) && isShooting == false) {
			if (transform.position.x <= 1.2f) {
				transform.Translate (Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.DownArrow) && isShooting == false) {
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.UpArrow) && isShooting == false) {
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}

		//======================= MOVEMENT =======================================================/

		if (Input.GetKey (KeyCode.RightAlt) || Input.GetKey (KeyCode.RightShift)) {

			isShooting = true;
			
			timePress += 1;
			//print (timePress);
			
			if (timePress < 20) {
				force1 = true;
			} else {
				force1 = false;
			}
			
			if (timePress >= 30 && timePress < 60) {
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


		if (Input.GetKeyUp (KeyCode.RightAlt)) {

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


			GameObject myBallon = Instantiate (balloonBall, shooter.position, shooter.rotation) as GameObject;
			myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * linethrust);
			
		}
		
		if (Input.GetKeyUp (KeyCode.RightShift)) {

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
			myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * thrust + transform.up * upthrust);

		}





		} 
	}

