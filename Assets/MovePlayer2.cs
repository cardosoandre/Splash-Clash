using UnityEngine;
using System.Collections;

public class MovePlayer2 : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public bool Shooting = false;
	public GameObject balloonBall;
	public Transform shooter;
	public float thrust;
	public float upthrust;
	public float linethrust;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (transform.position.x >= 0.114f) {
				transform.Translate (-Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (transform.position.x <= 1.2f) {
				transform.Translate (Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}

		if (Input.GetKeyDown (KeyCode.RightAlt)) {
			GameObject myBallon = Instantiate (balloonBall, shooter.position, shooter.rotation) as GameObject;
			myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * linethrust);
			
		}
		
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			GameObject myBallon = Instantiate (balloonBall, shooter.position, shooter.rotation) as GameObject;	
			myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * thrust + transform.up * upthrust);

		}
		} 
	}

