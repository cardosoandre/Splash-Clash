using UnityEngine;
using System.Collections;

public class moveCloud : MonoBehaviour {

	public float speed;
	public float rightlimit = 10;
	public float leftlimit = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Vector3.right * speed * Time.deltaTime;
		if (transform.position.x > rightlimit) {
			transform.position = new Vector3 (leftlimit,transform.position.y, 2.58f);
	
	}
}
}