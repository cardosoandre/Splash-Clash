using UnityEngine;
using System.Collections;

public class AniAudio1 : MonoBehaviour {

	public AudioClip aniClip1;
	AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource> ();
		audio.PlayOneShot (aniClip1);
	}

	void Update(){

	}
}
