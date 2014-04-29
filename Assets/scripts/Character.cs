using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	//Variables
	public float movementSpeed;
	public float turnSpeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//WASD controls
		float horizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // AD controls, or left-right arrows
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime; // WS controls or forward-back arrows
		transform.Translate(0, 0, vertical);
	}

	void OnCollisionEnter(Collision other){ //collision to detect if pacman hits a ghost, he "dies"

		if(other.gameObject.name == "GhostCaps" && Score_Controller.killPower <= 0){ //If Pacman don't have kill power ups, then Pacman will die
			Score_Controller.lifeCount--; //Takes one life if Pacman dies
			transform.position = new Vector3(0.0f, 0.5f, -14.0f); //Sends Pacman to start position
		}

		if( Score_Controller.lifeCount < 0){ // if Pacman has no any life left, then it is Game Over!
			Application.LoadLevel ("gameover"); //load another scene (gameover screen)
		}
	} 
}