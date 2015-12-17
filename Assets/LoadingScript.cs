using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(Application.GetStreamProgressForLevel("4 player prototype")==1){
			Invoke ("loadlev",3);
		}

		/*

		if (Application.GetStreamProgressForLevel ("4 player prototype") == 1) {
			Application.LoadLevel ("4 player prototype");
			Application.LoadLevelw ("4 player prototype");
		}
*/

	}

	void loadlev () {
		Application.LoadLevel ("4 player prototype");
	}




}
