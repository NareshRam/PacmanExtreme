using UnityEngine;
using System.Collections;

public class Score_Controller : MonoBehaviour {

	public static int scoreCount = 0; //Score have to begin with zero

	void OnGUI() //void to make GUI
	{
		string scoreText = "Total Score: " + scoreCount; //Text of GUI and total score
		GUI.Box(new Rect(Screen.width - 150, 20, 130, 20), scoreText); //The placement of GUI



	}

}
