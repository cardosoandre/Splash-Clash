using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	public Transform playerPosition;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = playerPosition.position + new Vector3 (0,-0.26f,0);
		if (player.GetComponent<BP1Mov> ().pressTime > 0) {
			gameObject.GetComponent<Animator> ().SetInteger ("State", 1);
		} else {
			gameObject.GetComponent<Animator> ().SetInteger ("State", 0);
		}
	
	}
}
