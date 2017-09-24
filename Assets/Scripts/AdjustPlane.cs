using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPlane : MonoBehaviour {

	private BoxCollider bc;
	private float zLength;
	private Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}
	// Use this for initialization
	void Start () {
		rb.velocity = transform.forward * -GameController.instance.moveSpeed;
		bc = GetComponentInParent<BoxCollider> ();
		zLength = bc.size.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z < -bc.size.z/1.5) {
			ResizePlane ();
		}
	}

	private void ResizePlane(){
		Vector3 leap = new Vector3 (0.0f, 0.0f, zLength*4);
		transform.position = transform.position + leap;
	}
}
