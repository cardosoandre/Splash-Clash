using UnityEngine;
using System.Collections;

public class CreditsButtonScript : MonoBehaviour {

	public GameObject buttonSound;
	
	public void onClick(){
		Instantiate (buttonSound);
		Application.LoadLevel("Credits");
	}
}
