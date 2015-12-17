using UnityEngine;
using System.Collections;

public class CreditsButtonScript : MonoBehaviour {

	public GameObject buttonSound;
	public GameObject hoverSound;
	
	public void onClick(){
		Instantiate (buttonSound);
		Invoke ("loadLevel", 2.0f);

	}

	public void OnPointerEnter(){ 
		//Debug.Log ("hovering");
		Instantiate (hoverSound);
	}
	
	void loadLevel(){
		Application.LoadLevel("Credits");
	}
}
