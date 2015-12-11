using UnityEngine;
using System.Collections;

public class poisonScript : MonoBehaviour {

	public GameObject poison;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("Player 2")) {
			Instantiate(poison, transform.position + new Vector3(0,0.08f,0),transform.rotation);
			Destroy (gameObject);
			other.GetComponent<BP1Mov> ().StartPoison();
		}
	}

}
