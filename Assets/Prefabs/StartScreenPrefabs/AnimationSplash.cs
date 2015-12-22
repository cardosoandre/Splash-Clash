using UnityEngine;
using System.Collections;

public class AnimationSplash : MonoBehaviour {
	public GameObject splash;
	public GameObject splash2;
	public GameObject sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Splashy (){
		Instantiate (splash, transform.position, transform.rotation);
		Instantiate (sound, transform.position, transform.rotation);
		Instantiate (splash2, transform.position, transform.rotation);
	}
}
