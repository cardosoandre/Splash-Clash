using UnityEngine;
using System.Collections;

public class randBalloonGen : MonoBehaviour {

	public GameObject bubblePowerUp;
	public GameObject poisonPowerUp;
	public GameObject bombPowerUp;

	public float minTime; //min time between power up appearance
	public float maxTime; //max time between power up appearance

	void Start(){

		float time1 = Random.Range (5, 10);
		float time2 = Random.Range (10, 20);
		float time3 = Random.Range (40, 50);

		Invoke ("SpawnBubble", time1);
		Invoke ("SpawnPoison", time2);
		Invoke ("SpawnBomb", 1);

	}

	void SpawnBubble(){
		float pos = Random.Range (-0.6f, 2.1f);
		Vector3 position =  new Vector3(0,0,pos);
		Instantiate (bubblePowerUp, position, Quaternion.identity);
		float time1 = Random.Range (25, 30);
		Invoke ("SpawnBubble", time1);
	}
	void SpawnPoison(){
		float pos = Random.Range (-0.6f, 2.1f);
		Vector3 position =  new Vector3(0,0,pos);
		Instantiate (poisonPowerUp, position, Quaternion.identity);
		float time2 = Random.Range (17, 20);
		Invoke ("SpawnPoison", time2);
	}
	void SpawnBomb(){
		float pos = Random.Range (-0.6f, 2.1f);
		Vector3 position =  new Vector3(0,0,pos);
		Instantiate (bombPowerUp, position, Quaternion.identity);
		//Invoke("SpawnBomb", Random.Range(5, 10));
	}
}