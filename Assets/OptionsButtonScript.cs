using UnityEngine;
using System.Collections;

public class OptionsButtonScript : MonoBehaviour {

	public GameObject buttonSound;
	
	public void onClick(){
		Instantiate (buttonSound);
		Application.LoadLevel("Options");
	}
}
