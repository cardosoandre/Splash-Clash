using UnityEngine;
using System.Collections;

public class explodeMid : MonoBehaviour {

	public GameObject splash;
	public GameObject fire;
	public GameObject blink;
	public GameObject sec;
	public bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (activated == false) {
			if (other.CompareTag ("BlueBalloon") || other.CompareTag ("RedBalloon")) {
				Instantiate (sec,transform.position,transform.rotation);
				GameObject omgfire = Instantiate(fire, transform.position + new Vector3(0,-0.18f,-0.05f), transform.rotation) as GameObject;
				GameObject whiteblink = Instantiate(blink,transform.position + new Vector3(0,0.1f,0),transform.rotation) as GameObject;
				omgfire.transform.parent = gameObject.transform;
				whiteblink.transform.parent = gameObject.transform;
				GetComponent<Animator>().SetInteger("State",1);
				GetComponentInChildren<shadowScript>().hit = true;
				activated = true;
				print ("hit");
				Invoke ("ExplodeMe", 10);
			}
		}
	}
	void ExplodeMe () {
		Destroy (gameObject);
		Instantiate (splash, transform.position, transform.rotation);
	}
}
