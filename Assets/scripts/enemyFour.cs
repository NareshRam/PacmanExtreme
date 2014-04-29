using UnityEngine;
using System.Collections;

//enemy #3, fiddler AI
public class enemyFour : MonoBehaviour {
	
	bool timerLoop = true; // Keeps the while-loop in the IEnumerator function running
	private NavMeshAgent nav; //using built-in navigation
	GameObject player; //make an object of Pacman
	private Transform playerTransform; //Getting Pacman's position
	private float fX; // Random X coordinates
	private float fZ; // Random Z coordinates

	//get player position
	Vector3 playerPos; //Assigning Pacman's position
	Vector3 RandPosition; // Random X-Z coordinates
	Vector3 runAway; // Coordinates for the enemy to run away to
	
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.cyan; //drawing the object cyan
		nav = GetComponent<NavMeshAgent>(); //Making use of the NavMesh-agent component
		StartCoroutine(MyWaitingTime()); // Run the Enum MyWaitingTime()
		
	}

	IEnumerator MyWaitingTime() // enum function MyWaitingTime is constantly called in Update, the while loop loops indefinetely, relatively randomizing destinations of the AI
	{
		while(timerLoop){ 

			fX = Random.Range(0, -28); //Random coordinates in the Top left Corner
			fZ = Random.Range(0, 28);
			yield return new WaitForSeconds (Random.Range (5, 20)); //The time before the cyan ghost gets a new random position, between 5 and 20 seconds

			fX = Random.Range(0, 27); //Random coordinates in the bottom right corner
			fZ = Random.Range(0, -26);
			yield return new WaitForSeconds (Random.Range (5, 20));

			fX = Random.Range(0, 27); //Random coordinates in the top right corner
			fZ = Random.Range(0, 28);
			yield return new WaitForSeconds (Random.Range (5, 20));

			fX = Random.Range(0, -27); //Random coordinatesbottom left corner
			fZ = Random.Range(0, -25);
			yield return new WaitForSeconds (Random.Range (5, 20));
		}
	}
	
	// Update is called once per frame
	void Update (){

		MyWaitingTime ();
		player = GameObject.FindWithTag ("Player"); // Finding Pacman
		playerTransform = player.transform; //Getting coordinates from Pacman
		playerPos = playerTransform.position; //The coordinates are assigned to the player's position
		RandPosition = new Vector3(fX, 0.5f, fZ); //The almost-random coordinates are put in the vector
		runAway = new Vector3(-1.55061f, 0.5f, -0.4118f); // Coordinates for the enemy to run away to

		if (playerPos.x >= fX - 10 && playerPos.x <= fX + 10 && Score_Controller.killPower <= 0) { //If statement for detecting Pacman if he is nearby            
			if (playerPos.z >= fZ - 10 && playerPos.z <= fZ + 10) { // If he is within the stated coordinates..
				nav.SetDestination (playerPos); //..Attack Pacman!
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
			transform.position = new Vector3(-1.55061f, 0.5f, -0.4118f); //Moves the ghost back to its original position
		}
	}
}