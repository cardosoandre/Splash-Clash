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
	public GameObject pressA;
	public GameObject win;
	public bool insta = false;
	public bool fold = false;

	// Use this for initialization
	void Start () {

		insta = false;
		pressA.GetComponent<SpriteRenderer> ().enabled = false;
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

		if (fold == false) {
			GetComponent<Animator> ().SetInteger ("State", 1);
			fold = true;
		}

		pressA.GetComponent<SpriteRenderer> ().enabled = true;

		KeyCode bbS = bb.GetComponent<BP1Mov> ().keySHOOT;
		KeyCode bgS = bg.GetComponent<BP1Mov> ().keySHOOT;
		KeyCode rbS = rb.GetComponent<BP1Mov> ().keySHOOT;
		KeyCode rgS = rg.GetComponent<BP1Mov> ().keySHOOT;


		if (waterTotal > 0 && gameObject.name == "R-SHIRT") {
			if (Input.GetKeyDown (bbS) || Input.GetKeyDown (bgS)){
			Instantiate (squish, transform.position, transform.rotation);
			waterTotal -= 5;
			}
		}
		if (waterTotal > 0 && gameObject.name == "B-SHIRT") {
			if (Input.GetKeyDown (rbS) || Input.GetKeyDown (rgS)){
			Instantiate (squish, transform.position, transform.rotation);
			waterTotal -= 5;
			}
		}
		if (waterTotal <= 0) {

			pressA.GetComponent<SpriteRenderer> ().enabled = false;

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
				
				GameObject[] bP = GameObject.FindGameObjectsWithTag ("Finish");
		
				GameObject[] rP = GameObject.FindGameObjectsWithTag ("Respawn");

			if (B.GetComponent<shirtScript>().waterResult < R.GetComponent<shirtScript>().waterResult){
				
					//RED TEAM WON

					if(insta == false){
						insta = true;
						Instantiate (win, R.transform.position, R.transform.rotation);
						
					}

					foreach (GameObject p in bP) {
						p.GetComponent<Animator>().SetInteger("State",3);
					}
					foreach (GameObject p in rP) {
						p.GetComponent<Animator>().SetInteger("State",2);
					}	

					result.GetComponent<TextMesh> ().text = ("RED TEAM WON");
					R.GetComponent<SpriteRenderer>().enabled = false;
					B.GetComponent<SpriteRenderer>().enabled = false;
			}
			
			if (B.GetComponent<shirtScript>().waterResult > R.GetComponent<shirtScript>().waterResult){

					//BLUE TEAM WON 

					if(insta == false){
						insta = true;
					Instantiate (win, B.transform.position, R.transform.rotation);

					}
				

					foreach (GameObject p in bP) {
						p.GetComponent<Animator>().SetInteger("State",2);
					}
					foreach (GameObject p in rP) {
						p.GetComponent<Animator>().SetInteger("State",3);
					}	

				result.GetComponent<TextMesh> ().text = ("BLUE TEAM WON");
					R.GetComponent<SpriteRenderer>().enabled = false;
					B.GetComponent<SpriteRenderer>().enabled = false;
			}
				if (B.GetComponent<shirtScript>().waterResult == R.GetComponent<shirtScript>().waterResult){

					//DRAW

					foreach (GameObject p in bP) {
						p.GetComponent<Animator>().SetInteger("State",2);
					}
					foreach (GameObject p in rP) {
						p.GetComponent<Animator>().SetInteger("State",2);
					}	

				result.GetComponent<TextMesh> ().text = ("DRAW");
					R.GetComponent<SpriteRenderer>().enabled = false;
					B.GetComponent<SpriteRenderer>().enabled = false;
			}

			}



		}
	}

}
