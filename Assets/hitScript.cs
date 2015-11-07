using UnityEngine;
using System.Collections;

public class hitScript : MonoBehaviour {

	public GameObject splash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Balloon") {
			print(other);
			Destroy (other);
			Instantiate(splash, transform.position, transform.rotation);
		}
	}


}
