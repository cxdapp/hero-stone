using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FullScreenVideo : MonoBehaviour {

	public GameObject canvas;
	public GameObject cube;


	// Use this for initialization
	void Start () {
		
		if (File.Exists(Application.persistentDataPath + "/userdata.dat")){
			canvas.SetActive(true);
			cube.SetActive(false);
		}else{
			canvas.SetActive(false);
			cube.SetActive(true);
			StartCoroutine (Wait ());
		}
		//Handheld.PlayFullScreenMovie ("openning.mp4", Color.white,FullScreenMovieControlMode.Full,FullScreenMovieScalingMode.AspectFit);
		//Handheld.PlayFullScreenMovie ("openning.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (24);
		canvas.SetActive(true);
		cube.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
