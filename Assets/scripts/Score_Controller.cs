using UnityEngine;
using System.Collections;

public class Score_Controller : MonoBehaviour {

	public static int scoreCount = 0; //Score have to begin with zero
	public static int lifeCount = 3; //Lives begin with three

	public static int killPower = 0; // Kill power up begins with zero

	public void OnGUI() //void to make GUI
	{
		string scoreText = "Total Score: " + scoreCount; //Text of GUI and total score
		GUI.Box(new Rect(Screen.width - 150, 5, 130, 20), scoreText); //The placement of GUI

		string livesText = "Lives: " + lifeCount; //Text of GUI and total amount of lives
		GUI.Box(new Rect(Screen.width - 150, 25, 130, 20), livesText); //The placement of GUI
		PlayerPrefs.SetInt (" ", scoreCount); 

		string killText = "Kill Power " + killPower; //Text of GUI and total amount of lives
		GUI.Box(new Rect(Screen.width - 150, 45, 130, 20), killText); //The placement of GUI
	}
}