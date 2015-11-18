using UnityEngine;
using System.Collections;

public class resultScreenControl : MonoBehaviour {

	public 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.C)) {

			Application.LoadLevel("4 player prototype");

		}

		//if (Input.GetKey (KeyCode.X)) {

		//	Application.LoadLevel("Start Screen");

		//}

	}
}
