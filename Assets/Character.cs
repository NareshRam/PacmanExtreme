using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.Euler(0, 0, 0);

		if(Input.GetKey(KeyCode("up") || KeyCode("down") || KeyCode("left") || KeyCode("right"))){
			if(Input.GetKey(KeyCode("up"))){
				transform.position += new Vector3(-0.2f, 0, 0); //when A is pressed Pacman will move left
			}
			
			if(Input.GetKey(KeyCode("down"))){
				transform.position += new Vector3(0.2f, 0, 0); //when D is pressed Pacman will move right
			}
			if(Input.GetKey(KeyCode("left"))){
				transform.position += new Vector3(0, 0, 0.2f); //when A is pressed Pacman will move left
			}
			
			if(Input.GetKey(KeyCode("right"))){
				transform.position += new Vector3(0, 0, -0.2f); //when D is pressed Pacman will move right
			}
		}
	}
}