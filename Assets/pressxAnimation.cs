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
		if (GetComponent<BP1Mov> ().hasBalloon == false && other.CompareTag ("Box")) {
		other.GetComponent<Animator> ().SetInteger ("State",1);
		}

		if (GetComponent<BP1Mov> ().hasBalloon == true && other.CompareTag ("Box")) {
		other.GetComponent<Animator> ().SetInteger ("State",0);
		}

	}

	void OnTriggerExit(Collider other) {
	if (other.CompareTag ("Box")){
		other.GetComponent<Animator> ().SetInteger ("State",0);
	}
		
	}


}
