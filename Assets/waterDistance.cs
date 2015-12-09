using UnityEngine;
using System.Collections;

public class waterDistance : MonoBehaviour {

	public float waterAmount = 10;
	public float radius;
	public float waterScore;


	// Use this for initialization
	void Start () {


		Collider[] thingsHit = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider other in thingsHit) {
			if (other.CompareTag ("Player") || other.CompareTag ("Player 2")) {
				float dist = Vector3.Distance (transform.position, other.transform.position);
				float percent = radius / dist;
				waterScore = percent * waterAmount;
				//print(waterScore);
				other.gameObject.SendMessage("getWet", waterScore);
				other.gameObject.SendMessage("GotHit");

			}
		}
	}
	
	// Update is called once per frame
	void Update () {



	}
}
