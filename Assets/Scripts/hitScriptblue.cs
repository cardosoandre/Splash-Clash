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
			Destroy (gameObject);
			Instantiate (splash, transform.position, transform.rotation);
		}

		if (other.tag == "Floor") {
			//Destroy (gameObject);
			//Instantiate(splash, transform.position, transform.rotation);
			//if (playerScript.GetComponent<MovePlayer>().force1 == true){


			//}else{
				Destroy (gameObject);
				Instantiate(splash, transform.position, transform.rotation);
			}
			}

	}

