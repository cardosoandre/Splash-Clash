using UnityEngine;
using System.Collections;

public class pressxAnimation : MonoBehaviour {

	public GameObject px;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerStay(Collider other) {

		if (GetComponent<BP1Mov> ().hasBalloon == true && other.CompareTag ("Box")) {
			if (GetComponent <BP1Mov> ().faceLeft == true && gameObject.tag == ("Player")) {
				other.GetComponent<Animator> ().SetInteger ("State", 2);
			} 
			if (GetComponent <BP1Mov> ().faceLeft == false && gameObject.tag == ("Player")) {
				other.GetComponent<Animator> ().SetInteger ("State", 0);
			} 
			if (GetComponent <BP1Mov> ().faceRight == true && gameObject.tag == ("Player 2")) {
				other.GetComponent<Animator> ().SetInteger ("State", 2);
			}
			if (GetComponent <BP1Mov> ().faceRight == false && gameObject.tag == ("Player 2")) {
				other.GetComponent<Animator> ().SetInteger ("State", 0);
			}
		}

		if (GetComponent<BP1Mov> ().hasBalloon == false && other.CompareTag ("Box")) {
			if (GetComponent <BP1Mov> ().faceLeft == true && gameObject.tag == ("Player")) {
				other.GetComponent<Animator> ().SetInteger ("State", 1);
			} 
			if (GetComponent <BP1Mov> ().faceLeft == false && gameObject.tag == ("Player")) {
				other.GetComponent<Animator> ().SetInteger ("State", 0);
			} 
			if (GetComponent <BP1Mov> ().faceRight == true && gameObject.tag == ("Player 2")) {
				other.GetComponent<Animator> ().SetInteger ("State", 1);
			}
			if (GetComponent <BP1Mov> ().faceRight == false && gameObject.tag == ("Player 2")) {
				other.GetComponent<Animator> ().SetInteger ("State", 0);
			}

		}
	}

	void OnTriggerExit(Collider other) {
	if (other.CompareTag ("Box")){
		other.GetComponent<Animator> ().SetInteger ("State",0);
	}
		
	}


}
