using UnityEngine;
using System.Collections;

public class shirtScript : MonoBehaviour {

	public GameObject splash;
	public GameObject squish;
	public int waterTotal;

	// Use this for initialization
	void Start () {

		waterTotal = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		//print (waterTotal);
	
	}

	public void Hit (float waterScore) {
		Invoke ("StopRot", 0.1f);
		float AngleAmount = (Mathf.Cos(Time.time * 20 ) * 180) / Mathf.PI * 0.5f;
		AngleAmount = Mathf.Clamp(AngleAmount, -15 , 15 );
		transform.localRotation = Quaternion.Euler( 0,0, AngleAmount);
		Instantiate (splash, transform.position + new Vector3 (0,0, -0.03f), transform.rotation);
		waterTotal = waterTotal + (int)waterScore;
	}

	void StopRot () {
		transform.localRotation = Quaternion.Euler( 0,0, 0);
	}

	public void Squish (){
		if (waterTotal > 0 && Input.GetKeyDown (KeyCode.G)) {
			Instantiate (squish, transform.position, transform.rotation);
			waterTotal -= 10;
		}
	}

}
