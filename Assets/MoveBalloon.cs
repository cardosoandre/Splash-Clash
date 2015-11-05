using UnityEngine;
using System.Collections;

public class MoveBalloon : MonoBehaviour {

	public float thrust;
	public GameObject balloonBoom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find ("Player").GetComponent<MovePlayer>().Shooting == true){
			gameObject.GetComponent<Rigidbody>().AddForce(transform.right * thrust);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			Instantiate (balloonBoom, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		
		
	
	}
}
