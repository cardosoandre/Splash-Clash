using UnityEngine;
using System.Collections;

public class MoveBalloon : MonoBehaviour {
	
	public GameObject balloonBoom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.P)) {
			Instantiate (balloonBoom, transform.position, transform.rotation);
			Destroy (gameObject);
		}

}
}
