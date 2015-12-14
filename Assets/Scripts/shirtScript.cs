using UnityEngine;
using System.Collections;

public class shirtScript : MonoBehaviour {

	public GameObject splash;
	public GameObject squish;
	public int waterTotal;
	public int waterResult;
	public GameObject bluescore;
	public GameObject redscore;
	public GameObject result;
	public GameObject bb,bg,rb,rg;

	// Use this for initialization
	void Start () {

		waterTotal = 0;
		waterResult = 0;
		bluescore.GetComponent<TextMesh> ().text = (" ");
		redscore.GetComponent<TextMesh> ().text = (" ");
		result.GetComponent<TextMesh> ().text = (" ");

	
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
		waterResult = waterResult + (int)waterScore;
	}

	void StopRot () {
		transform.localRotation = Quaternion.Euler( 0,0, 0);
	}

	public void Squish (){

		KeyCode bbS = bb.GetComponent<BP1Mov> ().keySHOOT;
		KeyCode bgS = bg.GetComponent<BP1Mov> ().keySHOOT;
		KeyCode rbS = rb.GetComponent<BP1Mov> ().keySHOOT;
		KeyCode rgS = rg.GetComponent<BP1Mov> ().keySHOOT;


		if (waterTotal > 0 && gameObject.name == "R-SHIRT") {
			if (Input.GetKeyDown (bbS) || Input.GetKeyDown (bgS)){
			Instantiate (squish, transform.position, transform.rotation);
			waterTotal -= 2;
			}
		}
		if (waterTotal > 0 && gameObject.name == "B-SHIRT") {
			if (Input.GetKeyDown (rbS) || Input.GetKeyDown (rgS)){
			Instantiate (squish, transform.position, transform.rotation);
			waterTotal -= 2;
			}
		}
		if (waterTotal <= 0) {

			GameObject B = GameObject.Find("R-SHIRT");
			GameObject R = GameObject.Find("B-SHIRT");


			if (gameObject.name == "R-SHIRT") {

				bluescore.GetComponent<TextMesh> ().text = waterResult.ToString();
				result.GetComponent<textFront>().red = true;
				//print ("BLUE SCORE IS: " + waterResult);
			}

			if (gameObject.name == "B-SHIRT") {
				redscore.GetComponent<TextMesh> ().text = waterResult.ToString();
				result.GetComponent<textFront>().blue = true;
				//print ("RED SCORE IS: " + waterResult);
			}

			if (result.GetComponent<textFront>().blue == true && result.GetComponent<textFront>().red == true){

			if (B.GetComponent<shirtScript>().waterResult < R.GetComponent<shirtScript>().waterResult){
				result.GetComponent<TextMesh> ().text = ("RED TEAM WON");
			}
				if (B.GetComponent<shirtScript>().waterResult > R.GetComponent<shirtScript>().waterResult){
				result.GetComponent<TextMesh> ().text = ("BLUE TEAM WON");
			}
				if (B.GetComponent<shirtScript>().waterResult == R.GetComponent<shirtScript>().waterResult){
				result.GetComponent<TextMesh> ().text = ("DRAW");
			}

			}



		}
	}

}
