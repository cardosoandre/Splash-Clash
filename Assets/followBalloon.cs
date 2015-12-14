using UnityEngine;
using System.Collections;

public class followBalloon : MonoBehaviour {

	public GameObject balloon;
	

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (balloon.transform.position.x, -0.2f, transform.position.z);
		transform.rotation = Quaternion.Euler(90, 0, 0);
	
	
	}
}
