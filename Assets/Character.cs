using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += new Vector3(0, 0, 0.2f); //make Pacman continously move forward
		
		if(Input.GetKey(KeyCode.A)){
			transform.position += new Vector3(-2.0f, 0, 0); //when A is pressed Pacman will move left
		}
		
		if(Input.GetKey(KeyCode.D)){
			transform.position += new Vector3(2.0f, 0, 0); //when D is pressed Pacman will move right
		}
	}
}