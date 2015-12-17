using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Application.LoadLevelAsync ("4 player prototype");

		/*

		if (Application.GetStreamProgressForLevel ("4 player prototype") == 1) {
			Application.LoadLevel ("4 player prototype");
			Application.LoadLevelw ("4 player prototype");
		}
*/

	}



}
