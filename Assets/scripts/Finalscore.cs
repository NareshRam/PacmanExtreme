using UnityEngine;
using System.Collections;

public class Finalscore : MonoBehaviour {
	public int finalScore;


	// Use this for initialization
	void Start () {
		finalScore = PlayerPrefs.GetInt(" "); //Acquires data for the score from the game scene (map.unity)

	}


	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {

		string scoreText = "FINAL SCORE: " + finalScore; // some pre-text for the score
		GUI.Box(new Rect(Screen.width/3, Screen.height/1.7f, 550 , 100), "<color=white><size=50>"+scoreText+"</size></color>"); // Making a new gui box for the score, making it white and sizing it to '50'
//		GUI.Box(new Rect(Screen.width/3, Screen.height/4, 400 , 100), "<color=red><size=50>"+"GAME OVER!" + "</size></color>"); // GUI LABEL FOR THE GAME OVER TEXT

		}

}
