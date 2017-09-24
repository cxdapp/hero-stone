using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainCollider : MonoBehaviour {

	public GameObject scoreObject;

	public float accelerateRate;
	public float m_DampTime = 0.2f;

	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject flames;

	private float m_ZoomSpeed;
	private Rigidbody rb;
	private float nextFire;
	private Camera m_Camera;
	private Vector3 tempPosition;
	private AudioSource audio1;
	private GameObject tempExplosion;
	private GameObject tempExplosion2;
	private bool isRunning;//是否按了加速

	private float t = 0.5f;
	private float x = 3.0f;
	private float a = 96.0f;
	private float oldtime;
	private float newtime;
	private Animator anim;
	int jumpHash = Animator.StringToHash("JUMP");
	int RjumpHash = Animator.StringToHash("RJUMP");

	private void Awake ()
	{
		m_Camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		tempPosition = m_Camera.transform.position-transform.position;
	}

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
		audio1 = GetComponent<AudioSource>();

	}
	void FixedUpadte(){
		
		//m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize,m_Camera.orthographicSize*2, ref m_ZoomSpeed, m_DampTime);



	}
	// Update is called once per frame
	void Update () {

		m_Camera.transform.position = transform.position + tempPosition;

		//if (Input.GetButton("Fire1") && Time.time > nextFire)
		//{
		//	GameController.instance.moveSpeed = GameController.instance.accelerateSpeed;
		//	StartCoroutine (jiasu ());
		//}


	}
	IEnumerator wait(float time){

		yield return new WaitForSeconds (time);
	}
	IEnumerator jiasu(){
		yield return new WaitForSeconds (0.5f);
		GameController.instance.moveSpeed = GameController.instance.originSpeed;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}


		if ((GameController.instance.moveSpeed == GameController.instance.originSpeed && (other.tag == "Enemy1"||other.tag == "Enemy2"))||other.tag == "Enemy") {
			audio1.Play ();
			tempExplosion = (GameObject)Instantiate (explosion, other.transform.position, other.transform.rotation);
			StartCoroutine(destroyBoom (tempExplosion));
			Destroy (other.gameObject);
			if (GameController.instance.isGod == false) {
				tempExplosion2 = (GameObject)Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				StartCoroutine (destroyBoom (tempExplosion2));
				Destroy (gameObject);
				GameController.instance.playerDead ();
			} else {
				StartCoroutine (isNotGod ());
			}

		}
		if (GameController.instance.moveSpeed>GameController.instance.originSpeed && other.tag == "Enemy1")
		{
			tempExplosion = (GameObject)Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			StartCoroutine( destroyBoom (tempExplosion));
			audio1.Play ();
			GameController.instance.addScore (5);
		}
		if (GameController.instance.moveSpeed>GameController.instance.originSpeed && other.tag == "Enemy2") {
			audio1.Play ();
			GameController.instance.addScore (5);
			tempExplosion = (GameObject)Instantiate (explosion, other.transform.position, other.transform.rotation);
			StartCoroutine(destroyBoom (tempExplosion));
			Destroy (other.gameObject);
			flames.SetActive(true);
			StartCoroutine (flamesdestroy (flames));
			GameController.instance.isGod = true;
			StartCoroutine (isNotGod ());

		}
		//Destroy(gameObject);
	}
	private IEnumerator flamesdestroy(GameObject gb){
		yield return new WaitForSeconds (3.0f);
		gb.SetActive (false);
	}
	private IEnumerator isNotGod(){
		yield return new WaitForSeconds (3.0f);
		GameController.instance.isGod = false;
	}
	private IEnumerator destroyBoom(GameObject go){
		yield return new WaitForSeconds (1.0f);
		Destroy (go);
	}

	private void Zoom ()
	{
		// Find the required size based on the desired position and smoothly transition to that size.
		float requiredSize = FindRequiredSize();
		m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
	}

	private float FindRequiredSize (){
		Vector3 targetLocalPos = transform.InverseTransformPoint(transform.position);
		return targetLocalPos.z;
	}
}
