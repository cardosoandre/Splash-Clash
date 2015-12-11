using UnityEngine;
using System.Collections;

public class bubblepop : MonoBehaviour {

	public GameObject balloon;
	int cntdwn = 50;
	bool strtcntdwn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (strtcntdwn == true) {

			cntdwn--;

		}

		if (cntdwn < 0) {

			Destroy(gameObject);

		}

	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "RedBalloon") {

			strtcntdwn = true;

			print("POP IT LIKE ITS HOT");

		}

	}
}
