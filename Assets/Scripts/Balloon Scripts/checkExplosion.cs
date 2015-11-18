using UnityEngine;
using System.Collections;

public class checkExplosion : MonoBehaviour {

	public float waterAmount = 2000f;
	public float explosionRadius = 10f;


	void Start () {
		Invoke ("destroySelf", GetComponent<ParticleSystem> ().duration);

		Collider[] thingsHit = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach(Collider c in thingsHit){
		if (c.CompareTag ("Player")) { //make Player 2, etc?
			float dist = Vector3.Distance(transform.position, c.transform.position);
			float percent = dist / explosionRadius;
			c.gameObject.SendMessage("getWet", waterAmount * percent);
		}
	}
}

void destroySelf(){
	Destroy(gameObject);
}

	
	}
}
