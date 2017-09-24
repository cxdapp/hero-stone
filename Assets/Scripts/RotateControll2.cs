using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControll2 : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		Input.multiTouchEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		int touchNum = Input.touchCount;

		if (touchNum > 0&&GameController.instance.gameOver!=true)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				if (touch.tapCount == 1)
				{
					anim.SetTrigger ("ROTATEME");
				}
				else
				{
					if (touch.tapCount == 2)
					{
						StartCoroutine (doubleClick ());
					}
				}
			}

		}
	}

	IEnumerator doubleClick(){
		GameController.instance.moveSpeed = GameController.instance.accelerateSpeed;
		yield return new WaitForSeconds (0.5f);
		GameController.instance.moveSpeed = GameController.instance.originSpeed;
	}
}
