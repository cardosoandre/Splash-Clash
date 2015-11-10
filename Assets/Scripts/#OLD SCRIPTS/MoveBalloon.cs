using UnityEngine;
using System.Collections;

public class MoveBalloon : MonoBehaviour {
	
	public GameObject balloonBoom;
	public bool canThrow;
	public float thrust;
	public float throwForce;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		throwForce = 0;
	
		if (Input.GetKeyDown (KeyCode.P)) {
			Instantiate (balloonBoom, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {

			throwForce = throwForce + 0.1f;

		}

		if(Input.GetKeyUp (KeyCode.Space)) {

			canThrow = true;

		}

		if (gameObject.GetComponent<MovePlayer> ().facingRight == true){
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.right * thrust);
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * throwForce);

		}
		if (gameObject.GetComponent<MovePlayer> ().facingLeft == true){
			gameObject.GetComponent<Rigidbody> ().AddForce (-transform.right * thrust);
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * throwForce);

		}
    }
}
