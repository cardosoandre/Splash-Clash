using UnityEngine;
using System.Collections;

public class pumpScript : MonoBehaviour {

	public KeyCode F;
	public float fill;

	// Use this for initialization
	void Start () {

		fill = 0;
	
	}

	void OnArea () {

		if (Input.GetKeyDown (F)) {
			fill += 1;
		}

		//print (fill);
		//print ("yeah");


		if (fill > 0 && fill < 2 && Input.GetKeyDown(F)){
			gameObject.GetComponent<Animator> ().SetInteger ("State", 1);
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
		}
		if (fill > 2 && fill < 4 && Input.GetKeyDown(F)){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 2);
		}
		if (fill > 4 && fill < 6 && Input.GetKeyDown(F)){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 3);
		}
		if (fill > 6 && fill < 8 && Input.GetKeyDown(F)){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch += 0.2f;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 4);
		}
		if (fill >= 10){
			GetComponent<AudioSource>().pitch = 1;
			gameObject.GetComponent<Animator> ().SetInteger ("State", 0);
			fill = 0;
		}
	}

	void Key (KeyCode keyFILL) {

		F = keyFILL;
	
	}

	void ExitArea () {
		//print ("out");
	}

}
