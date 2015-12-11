using UnityEngine;
using System.Collections;

public class bubbleScript : MonoBehaviour {

	public GameObject bubble;
	public GameObject splash;
	public Transform bboy;
	public Transform bgirl;
	public Transform rboy;
	public Transform rgirl;


	// Use this for initialization
	void Start () {

		bboy = GameObject.Find ("Blue BOY").transform;
		bgirl = GameObject.Find ("Blue GIRL").transform;
		rboy = GameObject.Find ("Red BOY").transform;
		rgirl = GameObject.Find ("Red GIRL").transform;


	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter (Collider other) {
		if (other.tag == ("BlueBalloon") || other.tag == ("RedBalloon")) {

			Destroy (gameObject);
			Instantiate(splash,transform.position + new Vector3(0,0.08f,0.02f),transform.rotation);

			if (other.GetComponent<whoDidIt> ().playerName == ("Blue BOY")) {
				if(GameObject.Find("Blue BOY").GetComponent<BP1Mov>().bubbleshield == false){
				GameObject shield = Instantiate (bubble, bboy.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Blue BOY").transform;
				GameObject.Find("Blue BOY").SendMessage("HasBubble");
				}
			}
			if (other.GetComponent<whoDidIt> ().playerName == ("Blue GIRL")) {
				if(GameObject.Find("Blue GIRL").GetComponent<BP1Mov>().bubbleshield == false){
				GameObject shield = Instantiate (bubble, bgirl.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Blue GIRL").transform;
				GameObject.Find("Blue GIRL").SendMessage("HasBubble");
				}
			}
			if (other.GetComponent<whoDidIt> ().playerName == ("Red BOY")) {
				if(GameObject.Find("Red BOY").GetComponent<BP1Mov>().bubbleshield == false){
				GameObject shield = Instantiate (bubble, rboy.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Red BOY").transform;
				GameObject.Find("Red BOY").SendMessage("HasBubble");
				}
			}
			if (other.GetComponent<whoDidIt> ().playerName == ("Red GIRL")) {
				if(GameObject.Find("Red GIRL").GetComponent<BP1Mov>().bubbleshield == false){
				GameObject shield = Instantiate (bubble, rgirl.position, transform.rotation) as GameObject;
				shield.transform.parent = GameObject.Find("Red GIRL").transform;
				GameObject.Find("Red GIRL").SendMessage("HasBubble");
				}
			}
		}
	}
}
