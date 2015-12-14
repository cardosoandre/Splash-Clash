using UnityEngine;
using System.Collections;

public class pauseScript : MonoBehaviour {

	private GameObject toptime;
	public bool pause = false;
	public GameObject bboy, bgirl, rboy, rgirl;

	// Use this for initialization
	void Start () {
	
		toptime = GameObject.Find ("TopTime");

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R) && pause == true || 
		    toptime.GetComponent<timerTest> ().done == true && Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("4 player prototype");
			unPause();

		}

		if (toptime.GetComponent<timerTest> ().done == false) {

			if (Input.GetKeyDown (KeyCode.Escape)) {
				if (pause == false) {
					Pause ();
				} else if (pause == true) {
					unPause ();
				}
			}

		}
	
	}

	void Pause () {
		toptime.SetActive(false);
		GetComponent<SpriteRenderer> ().enabled = true;
		//@@@@
		bboy.GetComponent<BP1Mov>().enabled = false;
		bgirl.GetComponent<BP1Mov>().enabled = false;
		rboy.GetComponent<BP1Mov>().enabled = false;
		rgirl.GetComponent<BP1Mov>().enabled = false;
		//@@@@
		Time.timeScale = 0;
		pause = true;
		toptime.GetComponent<timerTest> ().paused = true;
	}



	void unPause () {
		toptime.SetActive(true);
		GetComponent<SpriteRenderer> ().enabled = false;
		//@@@@
		bboy.GetComponent<BP1Mov>().enabled = true;
		bgirl.GetComponent<BP1Mov>().enabled = true;
		rboy.GetComponent<BP1Mov>().enabled = true;
		rgirl.GetComponent<BP1Mov>().enabled = true;
		//@@@@
		Time.timeScale = 1;
		pause = false;
		toptime.GetComponent<timerTest> ().paused = false;
	}
}
