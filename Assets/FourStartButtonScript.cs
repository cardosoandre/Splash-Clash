using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FourStartButtonScript : MonoBehaviour, IPointerEnterHandler {

	public GameObject buttonSound;
	public GameObject hoverSound;

	public void onClick(){
		Instantiate (buttonSound);
		Invoke ("loadLevel", 2.0f);
		//StartCoroutine (LoadLevel());

		//Debug.Log ("clicked");
	}

	public void OnPointerEnter(PointerEventData eventData){
		Debug.Log ("hovering");
		Instantiate (hoverSound);
	}

	void loadLevel(){
		Application.LoadLevel("LoadingScreen");
	}

	/*IEnumerator LoadLevel() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("4 player prototype");
	}*/

}