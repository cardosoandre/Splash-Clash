using UnityEngine;
using System.Collections;

public class hitScriptblue1: MonoBehaviour {

	public GameObject splash; 
	public GameObject sound;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player 2") {
			Destroy (gameObject);
			Instantiate (splash, transform.position, transform.rotation);
			Instantiate (sound, transform.position, transform.rotation);
		}
			

		if (other.tag == "Floor") {
			Destroy (gameObject);
			Instantiate(splash, transform.position, transform.rotation);
			}

	}


}
