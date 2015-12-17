using UnityEngine;
using System.Collections;

public class InstructionsButtonScript : MonoBehaviour {

	public GameObject buttonSound;
	
	public void onClick(){
		Instantiate (buttonSound);
		Invoke ("loadLevel", 2.0f);
	//	Debug.Log ("instr clicked");

	}
	void loadLevel(){
		Application.LoadLevel("Instructions");
	}
}
