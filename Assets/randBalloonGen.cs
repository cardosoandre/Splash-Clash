using UnityEngine;
using System.Collections;

public class randBalloonGen : MonoBehaviour {

	public GameObject balloonPowerUp;
	public float minTime; //min time between power up appearance
	public float maxTime; //max time between power up appearance
	private bool spawning = false;

	void Update(){

		if (!spawning && GameObject.FindWithTag ("PowerUp") == null) {
			SpawnObject();
		}
		Debug.Log ("spawning" + spawning);
	}

	IEnumerator SpawnObject(){

		spawning = true;

		yield return new WaitForSeconds(Random.Range(minTime, maxTime));
		Vector3 position = new Vector3 (0, 0, 0); //FIX #s Random.Range(2f,-0.8f)
		Instantiate(balloonPowerUp, position, Quaternion.identity);

		spawning = false;
	}
}