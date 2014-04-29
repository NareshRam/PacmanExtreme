using UnityEngine;
using System.Collections;

public class Finalscore : MonoBehaviour {
	public int finalScore;


	// Use this for initialization
	void Start () {
		finalScore = PlayerPrefs.GetInt(" ");

	}


	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {

		string scoreText = "FINAL SCORE: " + finalScore;
		GUI.Box(new Rect(Screen.width/3, Screen.height/1.7f, 400 , 100), "<color=white><size=50>"+scoreText+"</size></color>");
//		GUI.Box(new Rect(Screen.width/3, Screen.height/4, 400 , 100), "<color=red><size=50>"+"GAME OVER!" + "</size></color>"); // GUI LABEL FOR THE GAME OVER TEXT

		}

}
