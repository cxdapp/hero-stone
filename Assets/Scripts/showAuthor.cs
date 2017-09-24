using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showAuthor : MonoBehaviour {

	public GameObject go;
	public Text self;

	private int flag = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showAuth(){
		if (flag > 0) {
			go.SetActive(true);
			flag = -flag;
			self.text = "返回";
		} else {
			go.SetActive(false);
			flag = -flag;
			self.text = "制作人员";
		}

	}
}
