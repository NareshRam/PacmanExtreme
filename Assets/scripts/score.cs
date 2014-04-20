using UnityEngine;
using System.Collections;

// A SCOREBOARD THAT WILL COUNT UPWARDS THE LONGER THE PLAYER IS IN THE GAME

public class score : MonoBehaviour {
	
	
	public int points; //timer variable declared
	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "small_pebble"){
			points += 10; 
		}
	}
	
	void OnGUI(){
		GUI.Label(new Rect(10,10,250,100), "Score: " + points); //drawing a rectangle to show you the score
	}


}
