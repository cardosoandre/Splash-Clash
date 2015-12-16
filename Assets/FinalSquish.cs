using UnityEngine;
using System.Collections;

public class FinalSquish : MonoBehaviour {

	public KeyCode keySHOOT;
	public GameObject shirt;

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Renderer> ().sortingOrder = 99;
		shirt.GetComponent<Animator>().SetInteger ("State",1); 
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (keySHOOT)) {
			//print("hey");
			shirt.GetComponent<Animator> ().SetInteger ("State", 2);
			shirt.transform.localScale = new Vector3 (1.1f,1,1);
			GetComponent<Animator> ().SetInteger ("State", 1);
			gameObject.GetComponent<Renderer> ().sortingOrder = 6;
		} if (Input.GetKeyUp (keySHOOT)) {
			shirt.GetComponent<Animator> ().SetInteger ("State", 3);
			shirt.transform.localScale = new Vector3 (1,1,1);
			GetComponent<Animator> ().SetInteger ("State", 0);
			gameObject.GetComponent<Renderer> ().sortingOrder = 99;
		}

	}


}
