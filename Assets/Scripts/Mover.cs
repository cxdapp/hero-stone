using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * -GameController.instance.moveSpeed;
	}

	void Update(){
		rb.velocity = transform.forward * -GameController.instance.moveSpeed;
	}


}
