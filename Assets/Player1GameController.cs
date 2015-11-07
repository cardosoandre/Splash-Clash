using UnityEngine;
using System.Collections;
using InControl;

public class Player1GameController : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
    var InputDevice = InputManager.ActiveDevice;
		Debug.Log (InputDevice);
	}
}
