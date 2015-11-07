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
			print(other);
			Destroy (gameObject);
			Instantiate(splash, transform.position, transform.rotation);
			other.GetComponent<Animator>().Play("player 1 white flash");
		}

		if (other.tag == "Floor") {
				Destroy (gameObject);
				Instantiate(splash, transform.position, transform.rotation);
		}


	}


}
