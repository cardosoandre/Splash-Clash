using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public bool facingRight = true;
	public bool facingLeft;
	public GameObject balloonBall;
	public Transform shooter;
	public float thrust;

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

			facingLeft = true;
			facingRight = false;

			GetComponent<Animator>().SetInteger("State",2);
			if (transform.position.x >= -1.2f) {
				transform.Translate (-Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.D)) {

			facingRight = true;
			facingLeft = false;

			GetComponent<Animator>().SetInteger("State",1);
			if (transform.position.x <= 1.2f) {
				transform.Translate (Vector3.right * horizontalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			if (transform.position.z >= 0.105f) {
				transform.Translate (-Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.W)) {
			if (transform.position.z <= 2.1f) {
				transform.Translate (Vector3.forward * verticalSpeed * Time.deltaTime);
			}
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject myBallon = Instantiate (balloonBall, shooter.position, shooter.rotation) as GameObject;
			if (facingRight == true){
			myBallon.GetComponent<Rigidbody> ().AddForce (transform.right * thrust);
			}
			if (facingLeft == true){
			myBallon.GetComponent<Rigidbody> ().AddForce (-transform.right * thrust);
			}

		}
	}
}
