using UnityEngine;
using System.Collections;

public class InstructionsButtonScript : MonoBehaviour {

	public GameObject buttonSound;
	
	public void onClick(){
		Instantiate (buttonSound);
		Debug.Log ("instr clicked");
		Application.LoadLevel("Instructions");
	}
}
