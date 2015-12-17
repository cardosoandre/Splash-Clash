using UnityEngine;
using System.Collections;

public class FourStartButtonScript : MonoBehaviour {

	public GameObject buttonSound;

	public void onClick(){
		Instantiate (buttonSound);
		Application.LoadLevel ("LoadingScreen");
		//StartCoroutine (waitStart());

		//Debug.Log ("clicked");
	}
	/*
	IEnumerator waitStart() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("4 player prototype");
	}
	*/
}