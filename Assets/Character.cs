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
			rigidbody.AddForce (new Vector3(-20.0f, 0, 0)); //when A is pressed Pacman will move left in a smooth motion
		}
		
		if(Input.GetKey(KeyCode.D)){
			rigidbody.AddForce (new Vector3(20.0f, 0, 0)); //when D is pressed Pacman will move right in a smooth motion
		}
	}
}