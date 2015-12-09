using UnityEngine;
using System.Collections;

public class randBalloonGen : MonoBehaviour {

	public GameObject balloonPowerUp;
	public float minTime; //min time between power up appearance
	public float maxTime; //max time between power up appearance

	void Start(){

		Invoke ("SpawnObject", 2);

	}

	void SpawnObject(){
		float pos = Random.Range (-0.6f, 2.5f);
		Vector3 position =  new Vector3(0,0,pos);
		Instantiate (balloonPowerUp, position, Quaternion.identity);
		Invoke("SpawnObject", Random.Range(5, 10));
	}
}