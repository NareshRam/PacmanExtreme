using UnityEngine;
using System.Collections;

//enemy #1 the Chaser
public class Enemy : MonoBehaviour {
	
	private NavMeshAgent nav;
	GameObject player;
	private Transform playerTransform;
	
	//get player position
	Vector3 playerPos;
	//runAway Positions
	Vector3 runAway;
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		gameObject.renderer.material.color = Color.red; //drawing the object red
	}

	// Update is called once per frame
	void Update (){
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		playerPos = playerTransform.position;
		runAway = new Vector3(0.47104f, 0.5f, -0.2452f);

		if(Score_Controller.killPower > 0){
			nav.SetDestination(runAway);

		} else {
			nav.SetDestination (playerPos);
		}
	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Player" && Score_Controller.killPower > 0){
			Score_Controller.killPower--;//Takes kill power-up when it is used
			Score_Controller.scoreCount += 20; //Gives Pacman 20 score points
			transform.position = new Vector3(0.47104f, 0.5f, -0.2452f);
		}
	}
}