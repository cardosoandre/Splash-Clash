using UnityEngine;
using System.Collections;

public class textFront : MonoBehaviour {

	public bool red = false;
	public bool blue = false; 
	public bool pause = false;
	public GameObject timer;


	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<Renderer> ().sortingOrder = 99;
	
	}

	void Done () {

	}

}
