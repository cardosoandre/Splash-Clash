using UnityEngine;
using System.Collections;

public class MovBluPlay1 : MonoBehaviour {
	
	public bool isFilled = false;
	public float Xspeed;
	public float Yspeed;
	private float xscale;

	public bool faceRight;
	public bool faceLeft;
	public bool balloonPop;

	public float pumpTime;


	// Use this for initialization
	void Start () {
	
	xscale = transform.localScale.x;
	faceRight = true;
	balloonPop = true;

	}
	
	// Update is called once per frame
	void Update () {

		/*if (isFilled == false) {
		//	GetComponent<Animator> ().SetInteger ("State", 8);
		}
*/


		if (Input.GetKey (KeyCode.D) && isFilled == false && GetComponent<ShootBluPlay1>().isShooting == false) {

			faceLeft = false;
			faceRight = true;
			balloonPop = true;

			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.x <= -0.114f) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (Input.GetKey (KeyCode.A) && isFilled == false && GetComponent<ShootBluPlay1>().isShooting == false) {

			faceLeft = true;
			faceRight = false;
			balloonPop = true;

			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.x >= -1.2f) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if(!isFilled && balloonPop) {
			GetComponent<Animator> ().SetInteger ("State", 0);
		}

		if (Input.GetKey (KeyCode.S) && isFilled == false && GetComponent<ShootBluPlay1>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.W) && isFilled == false && GetComponent<ShootBluPlay1>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}

		//====WITH BALLOON 

		if (isFilled == true) {
			GetComponent<Animator> ().SetInteger ("State", 5);
		}

		if (Input.GetKey (KeyCode.D) && isFilled == true && GetComponent<ShootBluPlay1>().isShooting == false) {

			faceLeft = false;
			faceRight = true;

			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.x <= -0.114f) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (Input.GetKey (KeyCode.A) && isFilled == true && GetComponent<ShootBluPlay1>().isShooting == false) {

			faceLeft = true;
			faceRight = false;
			
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.x >= -1.2f) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (isFilled == true)  {
			GetComponent<Animator> ().SetInteger ("State", 5);
		}

		if (Input.GetKey (KeyCode.S) && isFilled == true && GetComponent<ShootBluPlay1>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.W) && isFilled == true && GetComponent<ShootBluPlay1>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
	
	}

	void OnTriggerStay(Collider other){
		if (other.CompareTag("Pump") && Input.GetKey (KeyCode.F) == true) {
			pumpTime = pumpTime +1; 
			if (pumpTime >= 80){
			isFilled = true;
			Debug.Log ("Filled? " + isFilled);
			}
		}
		if (Input.GetKeyUp(KeyCode.F)) {
			pumpTime = 0;
		}
	}
}
