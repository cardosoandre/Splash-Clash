using UnityEngine;
using System.Collections;

public class randBalloonGen : MonoBehaviour {

	public GameObject bubblePowerUp;
	public GameObject poisonPowerUp;
	public GameObject bombPowerUp;

	public float minTime; //min time between power up appearance
	public float maxTime; //max time between power up appearance

	void Start(){

		Invoke ("SpawnBubble", 5);
		Invoke ("SpawnPoison", 10);
		Invoke ("SpawnBomb", 15);

	}

	void SpawnBubble(){
		float pos = Random.Range (-0.6f, 2.1f);
		Vector3 position =  new Vector3(0,0,pos);
		Instantiate (bubblePowerUp, position, Quaternion.identity);
		//Invoke("SpawnBubble", Random.Range(5, 10));
	}
	void SpawnPoison(){
		float pos = Random.Range (-0.6f, 2.1f);
		Vector3 position =  new Vector3(0,0,pos);
		Instantiate (poisonPowerUp, position, Quaternion.identity);
		//Invoke("SpawnPoison", Random.Range(5, 10));
	}
	void SpawnBomb(){
		float pos = Random.Range (-0.6f, 2.1f);
		Vector3 position =  new Vector3(0,0,pos);
		Instantiate (bombPowerUp, position, Quaternion.identity);
		//Invoke("SpawnBomb", Random.Range(5, 10));
	}
}