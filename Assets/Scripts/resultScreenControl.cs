using UnityEngine;
using System.Collections;

public class resultScreenControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.C)) {

			Application.LoadLevel("Andre");

		}

		if (Input.GetKey (KeyCode.X)) {

			Application.LoadLevel("Start Screen");

		}

	}
}
