using UnityEngine;
using System.Collections;

// A SCOREBOARD THAT WILL COUNT UPWARDS THE LONGER THE PLAYER IS IN THE GAME

public class score : MonoBehaviour {
	
	
	public float timer; //timer variable declared
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
			timer += Time.deltaTime; //a timer 
	}
	
	void OnGUI() {
		
		float seconds = timer%60; //it will count in seconds
		
		GUI.Label (new Rect (10,10,250,100), "Score: " + Mathf.RoundToInt(seconds)); //makes it appear on the screen
		
	}
}
