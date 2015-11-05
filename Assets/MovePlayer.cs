using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public bool Shooting = false;
	public GameObject balloonBall;
	public Transform shooter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//if (transform.position.x >= -10 || transform.position.x <= 10) {
		//	transform.Translate (Vector3.right * horizontalSpeed * Input.GetAxis ("Horizontal"));
		//}
		
	//	if (transform.position.z >= -10 && transform.position.z <= 87) {
	//		transform.Translate (Vector3.forward * verticalSpeed * Input.GetAxis ("Vertical"));
	//	}

		if (Input.GetKey (KeyCode.A)) {
			if (transform.position.x >= -9) {
				transform.Translate (-Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if (transform.position.x <= 9) {
				transform.Translate (Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			if (transform.position.z >= 18) {
				transform.Translate (-Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.W)) {
			if (transform.position.z <= 85) {
				transform.Translate (Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}


		if (Input.GetKeyDown(KeyCode.Space)) {
			Shooting = true;
			Instantiate (balloonBall, shooter.position, shooter.rotation);
		} else {
			Shooting = false;
		}
	}
}
