using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByEnemy : MonoBehaviour {

	public GameObject player;

	private AudioSource audio1;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = player.GetComponent<Rigidbody> ();
		audio1 = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (rb.velocity.z <= Vector3.zero.z && other.tag == "Player") {
			audio1.Play ();
		}
	}
}
