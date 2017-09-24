using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RotateControll : MonoBehaviour {

	public float leaptime;
	public GameObject player;
	public Material sky1;
	public Material sky2;
	public GameObject light1;
	public GameObject light2;

	private float nextFire=2;
	private float waittime=0.3f;
	private Animator anim;
	private int countclicks;
	bool isPressed;

	private bool tag;

	void Awake(){
		anim = GetComponent<Animator>();
	}
	// Use this for initialization
	void Start () {
		
		light1.SetActive(true);
		light2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Fire1")&&GameController.instance.gameOver!=true )
		{
			countclicks++;
			if (isPressed == false) {
				StartCoroutine (CheckDown ());
			}
			//oldtime = Time.time;
			//GameController.instance.moveSpeed = GameController.instance.accelerateSpeed;
			//anim.SetTrigger ("ROTATEME");
		}
	}

	IEnumerator CheckDown(){
		isPressed = true;
		yield return new WaitForSeconds (waittime);

		if (countclicks == 1) {
			
			if (!File.Exists (Application.persistentDataPath + "/userdata.dat")&&tag==false) {
				GameController.instance.isPaused = false;
				Debug.Log ("isPaused:"+GameController.instance.isPaused );
				tag = true;
			} else {
				Changeskybox ();
				anim.SetTrigger ("ROTATEME");
				yield return new WaitForSeconds (0.1f);
				player.SetActive (false);
				yield return new WaitForSeconds (0.7f);
				player.SetActive (true);
			}

		} else if (countclicks >= 2) {

			GameController.instance.moveSpeed = GameController.instance.accelerateSpeed;
			GameController.instance.enemymoveSpeed = GameController.instance.enemyaccelerateSpeed;
			yield return new WaitForSeconds (0.5f);
			GameController.instance.moveSpeed = GameController.instance.originSpeed;
			GameController.instance.enemymoveSpeed = GameController.instance.enemyoriginSpeed;

		}
		countclicks = 0;
		isPressed = false;
	}
	void Changeskybox()
	{
		GameObject camera = Camera.main.gameObject;
		Skybox skybox = camera.GetComponent<Skybox> ();
		if (skybox.material == sky1){
			skybox.material = sky2;
			light1.SetActive (false);
			light2.SetActive (true);
		}
		else{
			skybox.material = sky1;
			light1.SetActive(true);
			light2.SetActive(false);
		}
}

}
