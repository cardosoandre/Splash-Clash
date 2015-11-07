using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

	public float destroytime; 

	// Use this for initialization
	void Start () {

		Destroy (gameObject, destroytime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
