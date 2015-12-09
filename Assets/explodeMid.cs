using UnityEngine;
using System.Collections;

public class explodeMid : MonoBehaviour {

	public GameObject splash;
	public bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (activated == false) {
			if (other.CompareTag ("BlueBalloon") || other.CompareTag ("RedBalloon")) {
				activated = true;
				GetComponent<AudioSource> ().Play ();
				print ("hit");
				Invoke ("ExplodeMe", 10);
			}
		}
	}
	void ExplodeMe () {
		Destroy (gameObject);
		Instantiate (splash, transform.position, transform.rotation);
	}
}
