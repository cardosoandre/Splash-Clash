using UnityEngine;
using System.Collections;

public class pumpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnArea (float pumpTime) {

		print (pumpTime);
		//print ("yeah");

		if (pumpTime > 0 && pumpTime < 2){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 1);
		}
		if (pumpTime > 2 && pumpTime < 4){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 2);
		}
		if (pumpTime > 4 && pumpTime < 6){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 3);
		}
		if (pumpTime > 6 && pumpTime < 8){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 4);
		}
		if (pumpTime >= 10){
			GetComponent<AudioSource>().pitch = 1;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 0);
		}
	}


	void ExitArea () {
		//print ("out");
	}

}
