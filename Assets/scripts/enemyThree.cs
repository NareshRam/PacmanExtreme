using UnityEngine;
using System.Collections;

//enemy #2, ambusher AI
public class enemyThree : MonoBehaviour {
	//Variables
	bool timerLoop = true; // Keeps the while-loop in the IEnumerator function running
	private NavMeshAgent nav; //using built-in navigation
	GameObject player; //make an object of Pacman
	private Transform playerTransform; //Getting Pacman's position
	private float aX; // Random X coordinates
	private float aZ; // Random Z coordinates
	
	//get player position
	Vector3 playerPos; //Assigning Pacman's position
	Vector3 RandPosition; // Random X-Z coordinates
	Vector3 runAway; // Coordinates for the enemy to run away to
	
	// Use this for initialization
	void Start () {

		gameObject.renderer.material.color = Color.magenta; //setting the colour to magenta (almost pink) 
		nav = GetComponent<NavMeshAgent>(); //Making use of the NavMesh-agent component
		StartCoroutine(MyWaitingTime()); // Run the Enum MyWaitingTime()
	}

	IEnumerator MyWaitingTime() 
	{
		while(timerLoop){
			aX = Random.Range(playerPos.x - 6, playerPos.x + 6); // Random coordinate-range between the min & max X values WITHIN close range of Pacman
			aZ = Random.Range(playerPos.z - 6, playerPos.z + 6); // Random coordinate-range between the min & max Z values WITHIN close range of Pacman
			yield return new WaitForSeconds (2.0f); //Updating the ghost's destination every two seconds
		}
	}
	
	// Update is called once per frame
	void Update (){

		MyWaitingTime (); 
		player = GameObject.FindWithTag ("Player"); // Finding Pacman
		playerTransform = player.transform; //Getting coordinates from Pacman
		playerPos = playerTransform.position; //The coordinates are assigned to the player's position
		RandPosition = new Vector3(aX, 0.5f, aZ); //The almost-random coordinates are put in the vector
		runAway = new Vector3(-0.73064f, 0.5f, 0.51779f); // Coordinates for the enemy to run away to

		if (playerPos.x >= aX - 4 && playerPos.x <= aX + 4 && Score_Controller.killPower <= 0) {   //If statement for detecting Pacman if he is nearby            
			if (playerPos.z >= aZ - 4 && playerPos.z <= aZ + 4) { // If he is within the stated coordinates..
				nav.SetDestination (playerPos); //..Attack Pacman!
			}
		}
		else if (Score_Controller.killPower > 0) { //If Pacman possesses killPower buff..
			nav.SetDestination (runAway); // ..Run away!
		} else {
			nav.SetDestination (RandPosition);  //Otherwise, go to a random position
		}
	}

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "Player" && Score_Controller.killPower > 0){ // If the ghost gets hit by pacman AND "killpower" buff is activated
			Score_Controller.killPower--;//Consumes kill power-up when it is used
			Score_Controller.scoreCount += 20; //Gives Pacman 20 score points
			transform.position = new Vector3(-0.73064f, 0.5f, 0.51779f); //Moves the ghost back to its original position
		}
	}
}