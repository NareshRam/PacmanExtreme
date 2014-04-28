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
		string scoreText = " " + finalScore;
		GUI.Box(new Rect(Screen.width/2, Screen.height/2-25, 40 , 50), scoreText);
		}

}
