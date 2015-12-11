using UnityEngine;
using System.Collections;

public class waterDistance : MonoBehaviour {

	public float waterAmount = 10;
	public float radius;
	public float waterScore;
	private GameObject redshirt;
	private GameObject blueshirt;


	// Use this for initialization
	void Start () {

		redshirt = GameObject.Find ("R-SHIRT");
		blueshirt = GameObject.Find ("B-SHIRT");



		Collider[] thingsHit = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider other in thingsHit) {
			if (other.CompareTag ("Player") || other.CompareTag ("Player 2")) {
				float dist = Vector3.Distance (transform.position, other.transform.position);
				float percent = radius / dist;
				waterScore = percent * waterAmount;
				//print(waterScore);
				other.gameObject.SendMessage("getWet", waterScore);
				other.gameObject.SendMessage("GotHit");

					if (other.CompareTag ("Player 2") && other.GetComponent<BP1Mov>().bubbleshield == false){
						redshirt.SendMessage("Hit");
					}

					if (other.CompareTag ("Player") && other.GetComponent<BP1Mov>().bubbleshield == false){
						blueshirt.SendMessage("Hit");
					}


			}
		}
	}
	
	// Update is called once per frame
	void Update () {



	}
}
