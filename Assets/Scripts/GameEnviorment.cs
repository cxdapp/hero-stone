using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnviorment : MonoBehaviour {

	public GameObject rain;

	// Use this for initialization
	void Start () {
		showRain ();
	}

	void showRain(){
		int t = Random.Range (0, 6);//3分之6
		if (t < 3) {
			StartCoroutine ("wait");
		} else {
			rain.SetActive (false);
		}
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (1);//等3s下雨
		rain.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
