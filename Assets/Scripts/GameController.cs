using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Mono.Data.Sqlite;

[System.Serializable]
public class User{
	public int bestScore;
	public bool issaved;
	public int lastscore;
}
public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject[] hazard;
	public GameObject gameOverText;
	public GameObject nextWaveText;
	public GameObject bestScoreText;
	public GameObject addscoretext;
	public GameObject guideText;
	public GameObject player;
	public Vector3 enemylocationLOW;
	public Vector3 enemylocationHIGH;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public int moveSpeed;
	public Text scoreText;
	public int score = 0;
	public int bestScore;
	public bool gameOver = false;
	public bool isDead = false;
	public bool isGod = false;

	public int originSpeed = 10;
	public int accelerateSpeed = 30;

	public int enemymoveSpeed;
	public int enemyoriginSpeed = 10;
	public int enemyaccelerateSpeed = 30;

	public bool isPaused;
	public bool isExist;
	public bool popmenuExist = false;
	public int rightAnswer=2;
	public bool IamRight=false;
	public bool tobecontinued;
	public bool isSaved;
	public int lastScore;

	void Awake()
	{
		Debug.Log ("Awake");
		moveSpeed = originSpeed;
		enemymoveSpeed = enemyoriginSpeed;

		if (instance == null) {
			//DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		Debug.Log ("Start");
		if (File.Exists (Application.persistentDataPath + "/userdata.dat")) {
			GameController.instance.isExist = true;
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/userdata.dat", FileMode.Open);
			User userdata = (User)bf.Deserialize (file);
			file.Close ();
			GameController.instance.bestScore = userdata.bestScore;

			if (userdata.issaved == true) {
				GameController.instance.score = userdata.lastscore;
				scoreText.text = "Score: " + GameController.instance.score;

			} else {
				GameController.instance.score = 0;
				scoreText.text = "Score: 0";
			}
			Debug.Log ("I have got score:" + GameController.instance.score + " and isSaved is " + GameController.instance.isSaved);
		} else {
			GameController.instance.bestScore = 0;
			Time.timeScale = 0;
			guideText.SetActive (true);
			GameController.instance.isPaused = true;
		}
		Debug.Log ("GameController.instance.bestScore :"+GameController.instance.bestScore );

		init ();
		StartCoroutine ("SpawnWaves");
	}

	public void init(){
		gameOver = false;
		GameController.instance.gameOver = false;
		isDead = false;
		isGod = false;
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (0.0f, 0.5f, Random.Range (enemylocationLOW.z, enemylocationHIGH.z));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard[Random.Range(0,3)], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			if (GameController.instance.gameOver != true) {
				yield return new WaitForSeconds (waveWait);
				nextWaveText.SetActive (true);
				yield return new WaitForSeconds (1.5f);
				nextWaveText.SetActive (false);
			}
		}
	}

	public void Save(){
		if (GameController.instance.isExist) {
			if (GameController.instance.score <= GameController.instance.bestScore) {

			} else {
				GameController.instance.bestScore = GameController.instance.score;
				//File.Delete (Application.persistentDataPath + "/userdata.dat");
				BinaryFormatter bf2 = new BinaryFormatter ();
				FileStream file2 = File.Create (Application.persistentDataPath + "/userdata.dat");
				User user2 = new User();
				user2.bestScore = GameController.instance.bestScore;
				bf2.Serialize (file2, user2);
				file2.Close ();
			}



		} else {
			GameController.instance.bestScore = GameController.instance.score;
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/userdata.dat");
			User user = new User ();
			user.bestScore = GameController.instance.bestScore;
			bf.Serialize (file, user);
			file.Close ();
		}
}	

	public void saveLastScore(){
		if (GameController.instance.isSaved = true) {
			BinaryFormatter bf2 = new BinaryFormatter ();
			FileStream file2 = File.Create (Application.persistentDataPath + "/userdata.dat");
			User user2 = new User();
			user2.issaved = true;
			user2.lastscore = GameController.instance.score;
			bf2.Serialize (file2, user2);
			file2.Close ();
		}
	}

	public int getLastScore(){
		int result;
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/userdata.dat", FileMode.Open);
		User userdata = (User)bf.Deserialize (file);
		if (userdata.issaved == true) {
			result = userdata.lastscore;
		} else {
			result = 0;
		}
		file.Close ();
		return result;
	}

	// Update is called once per frame
	void Update () {


		if (gameOver==true && GameController.instance.tobecontinued == true&&(Input.GetButton ("Fire1"))) {
			reloadScene ();
		}
        
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("welome");

		}

		if (GameController.instance.isPaused = true&&Input.GetButton ("Fire1")) {
			Time.timeScale = 1;
			guideText.SetActive (false);

		}
	}

	public void reloadScene(){
		gameOver = false;
		GameController.instance.gameOver = false;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void addScore(int mScore){
		score = score + mScore;
		GameController.instance.score = GameController.instance.score+mScore;
		Debug.Log ("score" + GameController.instance.score);
		scoreText.text = "Score: " + GameController.instance.score;

		addscoretext.SetActive (true);
		StartCoroutine (DeActiveObject (addscoretext, 0.45f));
	}

	IEnumerator DeActiveObject(GameObject go,float time){
		yield return new WaitForSeconds (time);
		go.SetActive (false);
	}

	public void playerDead(){
		GameController.instance.isSaved = false;
		isDead = true;
		gameOver = true;
		GameController.instance.gameOver = true;
		gameOverText.SetActive(true);

		Save ();

		bestScoreText.GetComponent<Text>().text = "最佳记录：" + GameController.instance.bestScore;
		bestScoreText.SetActive (true);
	}


}

