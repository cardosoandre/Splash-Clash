using UnityEngine;
using System.Collections;

public class hitScriptblue: MonoBehaviour {

	public GameObject splash; 
	private GameObject playerScript;
	private GameObject hitText;


	// Use this for initialization
	void Start () {

		playerScript = GameObject.Find ("Player Boy");
		hitText = GameObject.Find ("hitMe");

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player 2") {
			Destroy (gameObject);
			Instantiate (splash, transform.position, transform.rotation);
			hitText.GetComponent<TextMesh> ().text = ("OMG HIT!");
		} else {
			hitText.GetComponent<TextMesh> ().text = ("hm..");
		}
			

		if (other.tag == "Floor") {
			//Destroy (gameObject);
			//Instantiate(splash, transform.position, transform.rotation);
			if (playerScript.GetComponent<MovePlayer>().force1 == true){
				//Destroy (gameObject, 5);


			}else{
				Destroy (gameObject);
				Instantiate(splash, transform.position, transform.rotation);
			}
			}

	}


}
