using UnityEngine;
using System.Collections;

public class waterDistance : MonoBehaviour {

	public float waterAmount = 10;
	public float radius;
	public float RedScore = 0;
	public float BlueScore = 0;

	// Use this for initialization
	void Start () {


		Collider[] thingsHit = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider other in thingsHit) {
			if (other.CompareTag ("Player")) {
				//print(other);
				float dist = Vector3.Distance (transform.position, other.transform.position);
				float percent = radius / dist;
				float waterScore = percent * waterAmount;
				print ("RED" + waterScore);

				BlueScore = BlueScore + waterScore;
			}
			if (other.CompareTag ("Player 2")) {
				//print(other);
				float dist = Vector3.Distance (transform.position, other.transform.position);
				float percent = radius / dist;
				float waterScore = percent * waterAmount;
				print ("BLUE" + waterScore);
				
				RedScore = RedScore + waterScore;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
