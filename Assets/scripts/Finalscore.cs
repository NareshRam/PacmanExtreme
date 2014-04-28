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
		GUI.Box(new Rect(Screen.width/2-50, Screen.height/2-5, 125 , 60), scoreText);
		}

}
