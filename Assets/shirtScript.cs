using UnityEngine;
using System.Collections;

public class shirtScript : MonoBehaviour {

	public GameObject splash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Hit () {
		Instantiate (splash, transform.position + new Vector3 (0,0, -0.03f), transform.rotation);
	}
}
