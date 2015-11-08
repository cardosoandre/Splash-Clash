using UnityEngine;
using System.Collections;

public class instructionsControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.X)) {
			
			Application.LoadLevel("FINAL TEST SCENE");
			
		}

	}
}
