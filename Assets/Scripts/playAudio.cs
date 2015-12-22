using UnityEngine;
using System.Collections;

public class playAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GetComponent<AudioSource> ().Play ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
