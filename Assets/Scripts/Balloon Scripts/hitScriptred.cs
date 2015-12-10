using UnityEngine;
using System.Collections;

public class hitScriptred : MonoBehaviour {

	public GameObject splash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Destroy (gameObject);
			Instantiate(splash, transform.position, transform.rotation);
		}

		if (other.tag == "Floor") {
				Destroy (gameObject);
				Instantiate(splash, transform.position, transform.rotation);
		}

		if (other.tag == "Pump") {
			Destroy (gameObject);
			Instantiate(splash, transform.position, transform.rotation);
		}


	}


}
