using UnityEngine;
using System.Collections;

public class waterDistance : MonoBehaviour {

	public float waterAmount = 10;
	public float radius;

	// Use this for initialization
	void Start () {


		Collider[] thingsHit = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider other in thingsHit) {
			if (other.CompareTag ("Player")) {
				float dist = Vector3.Distance (transform.position, other.transform.position);
				float percent = radius / dist;
				//float waterScore = percent * waterAmount;
			}
			if (other.CompareTag ("Player 2")) {
				float dist = Vector3.Distance (transform.position, other.transform.position);
				float percent = radius / dist;
				//float waterScore = percent * waterAmount;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
