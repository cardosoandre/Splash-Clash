using UnityEngine;
using System.Collections;

public class moveFire : MonoBehaviour {

	public float speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Vector3.up * speed * Time.deltaTime;
	
	}
}
