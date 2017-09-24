using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPlayer : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver ();
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
