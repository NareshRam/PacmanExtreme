using UnityEngine;
using System.Collections;

//enemy #4, stupid AI
public class enemyTwo : MonoBehaviour {

	bool timerLoop = true; // Keeps the while-loop in the IEnumerator function running
	private NavMeshAgent nav; //using built-in navigation
	GameObject player; //make an object of Pacman
	private Transform playerTransform; //Getting Pacman's position
	private float randX; // Random X coordinates
	private float randZ; // Random Z coordinates
	
	//get player position
	Vector3 playerPos; //Assigning Pacman's position
	Vector3 RandPosition; // Random X-Z coordinates
	Vector3 runAway; // Coordinates for the enemy to run away to
	
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = new Color (1f, .65f, 0f); //setting the values for the color orange
		nav = GetComponent<NavMeshAgent>(); //Making use of the NavMesh-agent component
		StartCoroutine(MyWaitingTime()); // Run the Enum MyWaitingTime()
	}

	IEnumerator MyWaitingTime()
	{
		while(timerLoop){
			randX = Random.Range(-27.0f, 27.0f); // Random coordinate-range between the min & max X values
			randZ = Random.Range(-26.4f, 28.0f); // Random coordinate-range between the min & max Z values
			yield return new WaitForSeconds (20.0f); //The time before Orange ghost gets a new random position
		}
	}
	
	// Update is called once per frame
	void Update (){
		MyWaitingTime ();
		player = GameObject.FindWithTag ("Player"); // Finding Pacman 
		playerTransform = player.transform; //Getting coordinates from Pacman
		playerPos = playerTransform.position; //The coordinates are assigned to the player's position
		RandPosition = new Vector3(randX, 0.5f, randZ); //Random coordinates are put in the vector
		runAway = new Vector3(-2.31759f, 0.5f, 0.35637f); // Coordinates for the enemy to run away to

		if (playerPos.x >= randX - 9 && playerPos.x <= randX + 9 && Score_Controller.killPower <= 0) {    //If statement for detecting Pacman if he is nearby        
			if (playerPos.z >= randZ - 9 && playerPos.z <= randZ + 9) { // If he is within the stated coordinates..
				nav.SetDestination (playerPos); // ..Attack Pacman!
			}
		}
		else if (Score_Controller.killPower > 0) { //If Pacman possesses killPower buff..
			nav.SetDestination (runAway); // ..Run away!
		} else {
			nav.SetDestination (RandPosition); //Otherwise, go to a random position
		}
	}

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "Player" && Score_Controller.killPower > 0){ // If the ghost gets hit by pacman AND "killpower" buff is activated
			Score_Controller.killPower--;//Consumes kill power-up when it is used
			Score_Controller.scoreCount += 20; //Gives Pacman 20 score points
			transform.position = new Vector3(-2.31759f, 0.5f, 0.35637f); //Moves the ghost back to its original position
		}
	}
}