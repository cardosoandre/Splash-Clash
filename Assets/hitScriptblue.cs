using UnityEngine;
using System.Collections;

public class hitScriptblue: MonoBehaviour {

	public GameObject splash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player 2") {
			print(other);
			Destroy (gameObject);
			Instantiate(splash, transform.position, transform.rotation);
		}
	}


}
