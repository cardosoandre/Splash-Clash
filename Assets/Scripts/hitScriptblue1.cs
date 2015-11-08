using UnityEngine;
using System.Collections;

public class hitScriptblue1: MonoBehaviour {

	public GameObject splash; 
	private GameObject playerScript;



	// Use this for initialization
	void Start () {

		playerScript = GameObject.Find ("Blue Play 1");

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player 2") {
			Destroy (gameObject);
			Instantiate (splash, transform.position, transform.rotation);
		}
			

		if (other.tag == "Floor") {
			Destroy (gameObject);
			Instantiate(splash, transform.position, transform.rotation);
			if (playerScript.GetComponent<MovePlayer>().force1 == true){


			}else{
				Destroy (gameObject);
				Instantiate(splash, transform.position, transform.rotation);
			}
			}

	}


}
