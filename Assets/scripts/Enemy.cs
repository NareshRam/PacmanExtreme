using UnityEngine;
using System.Collections;

//enemy #1 the Chaser
public class Enemy : MonoBehaviour {
	//Variables

	private NavMeshAgent nav; //using built-in navigation
	GameObject player; //make an object of Pacman
	private Transform playerTransform; //Getting Pacman's position
	Vector3 playerPos; //Assigning Pacman's position
	Vector3 runAway; // Coordinates for the enemy to run away to
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>(); //Making use of the NavMesh-agent component
		gameObject.renderer.material.color = Color.red; //drawing the object red
	}

	// Update is called once per frame
	void Update (){
		player = GameObject.FindWithTag ("Player"); // Finding Pacman
		playerTransform = player.transform; //Getting coordinates from Pacman
		playerPos = playerTransform.position; //The coordinates are assigned to the player's position
		runAway = new Vector3(0.47104f, 0.5f, -0.2452f);  // Coordinates for the enemy to run away to

		if(Score_Controller.killPower > 0){ // If-statement to check if the kill-power buff is activated
			nav.SetDestination(runAway); // If its set, make the ghost run away

		} else { 
			nav.SetDestination (playerPos); //Otherwise, chase Pacman
		}
	}

	void OnCollisionEnter(Collision other){ // Colission function

		if (other.gameObject.tag == "Player" && Score_Controller.killPower > 0){ // If the ghost gets hit by pacman AND "killpower" buff is activated
			Score_Controller.killPower--;//Consumes kill power-up when it is used
			Score_Controller.scoreCount += 20; //Gives Pacman 20 score points
			transform.position = new Vector3(0.47104f, 0.5f, -0.2452f); // Moves the ghost to its original position
		}
	}
}