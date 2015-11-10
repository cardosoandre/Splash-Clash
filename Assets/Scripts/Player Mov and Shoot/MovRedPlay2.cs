using UnityEngine;
using System.Collections;

public class MovRedPlay2 : MonoBehaviour {
	
	public bool isFilled = false;
	public float Xspeed;
	public float Yspeed;
	private float xscale;
	
	public bool faceRight;
	public bool faceLeft;
	public bool balloonPop;
	
	public float pumpTime;

	public float upLimit;
	public float downLimit;
	public float leftLimit;
	public float rightLimit;
	

	// Use this for initialization
	void Start () {
		
		xscale = transform.localScale.x;
		faceRight = true;
		balloonPop = true;
		transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (isFilled == false) {
		//	GetComponent<Animator> ().SetInteger ("State", 8);
		}
*/
		
		
		if (Input.GetKey (KeyCode.V) && isFilled == false && GetComponent<ShootRedPlay2>().isShooting == false) {
			
			faceLeft = false;
			faceRight = true;
			balloonPop = true;
			
			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.x <= rightLimit) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (Input.GetKey (KeyCode.C) && isFilled == false && GetComponent<ShootRedPlay2>().isShooting == false) {
			
			faceLeft = true;
			faceRight = false;
			balloonPop = true;
			
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.x >= leftLimit) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if(!isFilled && balloonPop) {
			GetComponent<Animator> ().SetInteger ("State", 0);
		}
		
		if (Input.GetKey (KeyCode.X) && isFilled == false && GetComponent<ShootRedPlay2>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.z >= downLimit) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.Z) && isFilled == false && GetComponent<ShootRedPlay2>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.z <= upLimit) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		
		//====WITH BALLOON 
		
		if (isFilled == true) {
			GetComponent<Animator> ().SetInteger ("State", 5);
		}
		
		if (Input.GetKey (KeyCode.V) && isFilled == true && GetComponent<ShootRedPlay2>().isShooting == false) {
			
			faceLeft = false;
			faceRight = true;
			
			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.x <= rightLimit) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (Input.GetKey (KeyCode.C) && isFilled == true && GetComponent<ShootRedPlay2>().isShooting == false) {
			
			faceLeft = true;
			faceRight = false;
			
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.x >= leftLimit) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (isFilled == true)  {
			GetComponent<Animator> ().SetInteger ("State", 5);
		}
		
		if (Input.GetKey (KeyCode.X) && isFilled == true && GetComponent<ShootRedPlay2>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.z >= downLimit) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.Z) && isFilled == true && GetComponent<ShootRedPlay2>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.z <= upLimit) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		
	}
	
	void OnTriggerStay(Collider other){

		if (other.CompareTag("Pump") && Input.GetKey (KeyCode.G)) {
			if (isFilled == false){
				other.GetComponent<Animator>().SetInteger("State",1);
			}
			GetComponent<ShootRedPlay2>().isShooting = true;
			pumpTime = pumpTime +1; 
			if (pumpTime >= 80){
				GetComponent<ShootRedPlay2>().isShooting = false;
				other.GetComponent<Animator>().SetInteger("State",0);
				isFilled = true;
				Debug.Log ("Filled? " + isFilled);
			}
		}
		if (Input.GetKeyUp(KeyCode.G)) {
			GetComponent<ShootRedPlay2>().isShooting = false;
			pumpTime = 0;
		}
	}
}