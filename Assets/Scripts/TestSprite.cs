using UnityEngine;
using System.Collections;

public class TestSprite : MonoBehaviour {

	private float xscale;

	// Use this for initialization
	void Start () {
	
		xscale = transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Animator> ().SetInteger ("State", 1);
			transform.localScale = new Vector3 (xscale, transform.localScale.y, transform.localScale.z);
		}

		else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.localScale = new Vector3 (-xscale, transform.localScale.y, transform.localScale.z);
			GetComponent<Animator> ().SetInteger ("State", 1);
		} else {
			GetComponent<Animator> ().SetInteger ("State", 2);
		}

		if (Input.GetKey (KeyCode.Space)) {
			GetComponent<Animator> ().SetInteger ("State", 3);
		} 

		if (Input.GetKey (KeyCode.P)) {
			GetComponent<Animator> ().SetInteger ("State", 4);
		} 


	
	}
}
