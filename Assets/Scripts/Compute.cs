using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Compute : MonoBehaviour {

	public Text content;
	public GameObject tobecontinued;
	public Button choiceA;
	public Button choiceB;
	public Button choiceC;
	public Button choiceD;
	public Material m3;

	public Sprite right;
	public Sprite wrong;
	public GameObject problemPanel;
	public GameObject popMenu;


	private Animator p_anim;
	private SQLiteHelper sql;

	public IEnumerator wait(float time){
		yield return new WaitForSeconds (time);
	}

	public void judgeA(){
		if (GameController.instance.rightAnswer == 0) {
			Image img = choiceA.GetComponent<Image> ();
			img.sprite = right;
			GameController.instance.isSaved = true;
			GameController.instance.lastScore = GameController.instance.score;
		} else {
			Image img = choiceA.GetComponent<Image> ();
			img.sprite = wrong;
			GameController.instance.isSaved = false;
		}
		p_anim.SetTrigger ("FINISH");
		GameController.instance.tobecontinued = true;
		StartCoroutine (wait (1f));
		tobecontinued.SetActive (true);
		saveLastScore ();
	}

	public void judgeB(){
		if (GameController.instance.rightAnswer == 1) {
			Image img = choiceB.GetComponent<Image> ();
			img.sprite = right;
			GameController.instance.isSaved = true;
			GameController.instance.lastScore = GameController.instance.score;
		} else {
			Image img = choiceB.GetComponent<Image> ();
			img.sprite = wrong;
			GameController.instance.isSaved = false;
		}
		p_anim.SetTrigger ("FINISH");
		GameController.instance.tobecontinued = true;
		StartCoroutine (wait (1f));
		tobecontinued.SetActive (true);
		saveLastScore ();
	}

	public void judgeC(){
		if (GameController.instance.rightAnswer == 2) {
			Image img = choiceC.GetComponent<Image> ();
			img.sprite = right;
			GameController.instance.isSaved = true;
			GameController.instance.lastScore = GameController.instance.score;
			Debug.Log ("lastscore:"+GameController.instance.lastScore);
		} else {
			Image img = choiceC.GetComponent<Image> ();
			img.sprite = wrong;
			GameController.instance.isSaved = false;
		}
		p_anim.SetTrigger ("FINISH");
		GameController.instance.tobecontinued = true;
		StartCoroutine (wait (1f));
		tobecontinued.SetActive (true);
		saveLastScore ();
	}

	public void judgeD(){
		if (GameController.instance.rightAnswer == 3) {
			Image img = choiceD.GetComponent<Image> ();
			img.sprite = right;
			GameController.instance.isSaved = true;
			GameController.instance.lastScore = GameController.instance.score;
		} else {
			Image img = choiceD.GetComponent<Image> ();
			img.sprite = wrong;
			GameController.instance.isSaved = false;
		}
		p_anim.SetTrigger ("FINISH");
		GameController.instance.tobecontinued = true;
		StartCoroutine (wait (1f));
		tobecontinued.SetActive (true);
		saveLastScore ();
	}

	public void saveLastScore(){
			BinaryFormatter bf2 = new BinaryFormatter ();
			FileStream file2 = File.Create (Application.persistentDataPath + "/userdata.dat");
			User user2 = new User();
			user2.bestScore = GameController.instance.bestScore;
			user2.issaved = GameController.instance.isSaved;
			user2.lastscore = GameController.instance.score;
			bf2.Serialize (file2, user2);
			file2.Close ();
		Debug.Log("I have saved score:" + GameController.instance.score + " and isSaved is " + GameController.instance.isSaved);
	}
	// Use this for initialization
	void Start () {
		p_anim = problemPanel.GetComponent<Animator> ();
		if (File.Exists (Application.persistentDataPath + "/problemdata2.db")) {
			sql = new SQLiteHelper ("URI=file:" + Application.persistentDataPath + "/problemdata2.db");
		} else {
			sql = new SQLiteHelper ("URI=file:" + Application.persistentDataPath + "/problemdata2.db");
			sql.CreateTable ("ProblemTable", new string[]{ "id", "content", "choiceA","choiceB","choiceC","choiceD", "rightAnswer","isRight" }, new string[] {
				"INTEGER",
				"TEXT",
				"TEXT",
				"TEXT",
				"TEXT",
				"TEXT",
				"INTEGER",
				"INTEGER"
			});
			sql.InsertValues ("ProblemTable", new string[]{ "1", "'以下哪部作品不是中国古典文学？'", "'《三侠五义》'","'《镜花缘》'","'《谢氏南征记》'","'《平妖传》'", "2","0" });
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == true) {
			if(GameController.instance.popmenuExist==false)
				popMenu.SetActive (true);
			GameController.instance.popmenuExist = true;
		}

		if (GameController.instance.IamRight == true) {

		}
	}

	public void changePanel(){
		GameController.instance.popmenuExist = true;
		popMenu.SetActive (false);
		problemPanel.SetActive (true);
		string s=null;
		SqliteDataReader reader = sql.ReadFullTable ("ProblemTable");//替换
		while (reader.Read ()) {
			s = reader.GetString (reader.GetOrdinal ("content") )+ "\n" +
				"A. "+reader.GetString (reader.GetOrdinal ("choiceA") )+ "\n" +
				"B. "+reader.GetString (reader.GetOrdinal ("choiceB") )+ "\n" +
				"C. "+reader.GetString (reader.GetOrdinal ("choiceC") )+ "\n" +
				"D. "+reader.GetString (reader.GetOrdinal ("choiceD") );
			GameController.instance.rightAnswer = reader.GetInt32 (reader.GetOrdinal ("rightAnswer"));
			Debug.Log ("正确答案："+GameController.instance.rightAnswer);
			Debug.Log ("scoreeeeeeee:" + GameController.instance.score);
			break;
		}
		content.text = s;
		sql.CloseConnection ();

	}
}
