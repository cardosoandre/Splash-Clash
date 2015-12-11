using UnityEngine;
using System.Collections;

public class testInsideSphere : MonoBehaviour {

	public float waterAmount = 10;
	public float radius;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Collider[] thingsHit = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider other in thingsHit) {
			if (other.CompareTag ("Player")) {
				float dist = Vector3.Distance (transform.position, other.transform.position);
				float percent = radius / dist;
				print(percent * waterAmount);
				//other.gameObject.SendMessage ("wet", waterAmount * percent);
			}
		}
	
	}



}
