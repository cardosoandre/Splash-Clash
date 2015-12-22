using UnityEngine;
using System.Collections;

public class FourStartButtonScript : MonoBehaviour  { 

	public GameObject buttonSound;
	public GameObject hoverSound;

	public void onClick(){
		Instantiate (buttonSound);
		Invoke ("loadLevel", 0.5f);
		//Debug.Log ("clicked");
	}

	public void OnPointerEnter(){ 
		//Debug.Log ("hovering");
		Instantiate (hoverSound);
	}

	void loadLevel(){
		Application.LoadLevel("LoadingScreen");
	}

}