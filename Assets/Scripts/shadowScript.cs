using UnityEngine;
using System.Collections;

public class shadowScript : MonoBehaviour {

	public bool hit;

	// Use this for initialization
	void Start () {

		hit = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (hit == true) {
			GetComponent<Animator> ().SetInteger ("State", 1);
		}

	}
}
