using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button (new Rect(Screen.width/2.1f, Screen.height/1.3f, 100, 30), "QUIT GAME")){

			Application.Quit ();
		}
	}
}
