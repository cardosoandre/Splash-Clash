using UnityEngine;
using System.Collections;

public class MovRedPlay4 : MonoBehaviour {

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
		transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (isFilled == false) {
		//	GetComponent<Animator> ().SetInteger ("State", 8);
		}
*/
		
		
		if (Input.GetKey ("4") && isFilled == false && GetComponent<ShootRedPlay4>().isShooting == false) {
			
			faceLeft = false;
			faceRight = true;
			balloonPop = true;
			
			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.x <= 1.2f) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (Input.GetKey ("3") && isFilled == false && GetComponent<ShootRedPlay4>().isShooting == false) {
			
			faceLeft = true;
			faceRight = false;
			balloonPop = true;
			
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.x >= 0.11f) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if(!isFilled && balloonPop) {
			GetComponent<Animator> ().SetInteger ("State", 0);
		}
		
		if (Input.GetKey ("2") && isFilled == false && GetComponent<ShootRedPlay4>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		if (Input.GetKey ("1") && isFilled == false && GetComponent<ShootRedPlay4>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 2);
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		
		//====WITH BALLOON 
		
		if (isFilled == true) {
			GetComponent<Animator> ().SetInteger ("State", 5);
		}
		
		if (Input.GetKey ("4") && isFilled == true && GetComponent<ShootRedPlay4>().isShooting == false) {
			
			faceLeft = false;
			faceRight = true;
			
			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.x <= 1.2f) {
				transform.Translate (Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (Input.GetKey ("3") && isFilled == true && GetComponent<ShootRedPlay4>().isShooting == false) {
			
			faceLeft = true;
			faceRight = false;
			
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.x >= 0.11f) {
				transform.Translate (-Vector3.right * Xspeed * Time.deltaTime);
			}
		} else if (isFilled == true)  {
			GetComponent<Animator> ().SetInteger ("State", 5);
		}
		
		if (Input.GetKey ("2") && isFilled == true && GetComponent<ShootRedPlay4>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		if (Input.GetKey ("1") && isFilled == true && GetComponent<ShootRedPlay4>().isShooting == false) {
			GetComponent<Animator> ().SetInteger ("State", 6);
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * Yspeed * Time.deltaTime);
			}
		}
		
	}
	
	void OnTriggerStay(Collider other){
		if (other.CompareTag("Pump") && Input.GetKey ("5") == true) {
			if (isFilled == false){
				other.GetComponent<Animator>().SetInteger("State",1);
			}
			pumpTime = pumpTime +1; 
			if (pumpTime >= 80){
				other.GetComponent<Animator>().SetInteger("State",0);
				isFilled = true;
				Debug.Log ("Filled? " + isFilled);
			}
		}
		if (Input.GetKeyUp("5")) {
			pumpTime = 0;
		}
	}
}
