using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * -GameController.instance.enemymoveSpeed;
	}

	void Update(){
		rb.velocity = transform.forward * -GameController.instance.enemymoveSpeed;
	}

}
