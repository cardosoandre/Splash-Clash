using UnityEngine;
using System.Collections;

public class bubbleScript : MonoBehaviour {

	public GameObject bubble;
	public GameObject splash;
	public Transform bboy;
	public Transform bgirl;

	// Use this for initialization
	void Start () {

		bboy = GameObject.Find ("Blue BOY").transform;
		bgirl = GameObject.Find ("Blue BOY").transform;


	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter (Collider other) {
		if (other.tag == ("BlueBalloon") || other.tag == ("RedBalloon")) {

			Destroy (gameObject);
			Instantiate(splash,transform.position + new Vector3(0,0.08f,0.02f),transform.rotation);

			if (other.GetComponent<whoDidIt> ().playerName == ("Blue BOY")) {
				GameObject shield = Instantiate (bubble, bboy.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Blue BOY").transform;
				GameObject.Find("Blue BOY").SendMessage("HasBubble");
			}
			if (other.GetComponent<whoDidIt> ().playerName == ("Blue GIRL")) {
				GameObject shield = Instantiate (bubble, bgirl.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Blue GIRL").transform;
				GameObject.Find("Blue GIRL").SendMessage("HasBubble");
			}
			/*if (other.GetComponent<whoDidIt> ().playerName == ("Blue BOY")) {
				GameObject shield = Instantiate (bubble, bboy.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Blue BOY").transform;
				GameObject.Find("Blue BOY").SendMessage("HasBubble");
			}
			if (other.GetComponent<whoDidIt> ().playerName == ("Blue BOY")) {
				GameObject shield = Instantiate (bubble, bboy.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Blue BOY").transform;
				GameObject.Find("Blue BOY").SendMessage("HasBubble");
			}*/
		}
	}
}
