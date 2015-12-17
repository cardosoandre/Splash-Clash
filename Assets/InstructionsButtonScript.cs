using UnityEngine;
using System.Collections;

public class InstructionsButtonScript : MonoBehaviour {

	public GameObject buttonSound;
	public GameObject hoverSound;
	
	public void onClick(){
		Instantiate (buttonSound);
		Invoke ("loadLevel", 2.0f);
	//	Debug.Log ("instr clicked");

	}

	public void OnPointerEnter(){ 
		//Debug.Log ("hovering");
		Instantiate (hoverSound);
	}

	void loadLevel(){
		Application.LoadLevel("Instructions");
	}
}
