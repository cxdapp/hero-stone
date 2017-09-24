using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {


	public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


		if (Input.GetKey (KeyCode.Space) && SceneManager.GetActiveScene().name=="day") {
			SceneManager.MoveGameObjectToScene(player,SceneManager.GetSceneByName("night"));
			//SceneManager.LoadScene("night",LoadSceneMode.Single);
			SceneManager.LoadScene("night");
		}
		if (Input.GetKey (KeyCode.Space) && SceneManager.GetActiveScene().name=="night") {
			SceneManager.MoveGameObjectToScene(player,SceneManager.GetSceneByName("day"));
			SceneManager.LoadScene("day",LoadSceneMode.Single);
				
		}
	}
}
