using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayVideo : MonoBehaviour {

	public GameObject canvas;
	public GameObject cube;

	//public MovieTexture movie;
	public AudioClip backaudio;

	private AudioSource myaudio;


	void Start () {
		//GetComponent<RawImage> ().texture = movie as MovieTexture;
		myaudio = GetComponent<AudioSource> ();
		//myaudio.clip = movie.audioClip;

		//movie.Play ();
		myaudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		//if ((Input.GetButton ("Fire1")&&movie.isPlaying)) {
		//	movie.Stop ();
		//	myaudio.clip = backaudio;
		//	myaudio.Play ();
		//}

		//if (movie.isPlaying) {
		//	canvas.SetActive (false);
		//} else {
		//	canvas.SetActive (true);
		//}
	}
}
