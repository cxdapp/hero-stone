using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByBoundry : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		// Destroy everything that leaves the trigger
		if (other.tag == "Enemy"||other.tag == "Enemy1"||other.tag == "Enemy2") {
			Destroy (other.gameObject);
		}
	}
}
