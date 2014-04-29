using UnityEngine;
using System.Collections;

//enemy #2, ambusher AI
public class enemyThree : MonoBehaviour {
	
	bool timerLoop = true;
	private NavMeshAgent nav;
	GameObject player;
	private Transform playerTransform;
	private float aX;
	private float aZ;
	
	//get player position
	Vector3 playerPos;
	Vector3 RandPosition;
	Vector3 runAway;
	
	// Use this for initialization
	void Start () {

		gameObject.renderer.material.color = Color.magenta; //setting the values for the color pink
		nav = GetComponent<NavMeshAgent>();
		StartCoroutine(MyWaitingTime());
	}

	IEnumerator MyWaitingTime()
	{
		while(timerLoop){
			aX = Random.Range(playerPos.x - 6, playerPos.x + 6);
			aZ = Random.Range(playerPos.z - 6, playerPos.z + 6);
			yield return new WaitForSeconds (2.0f);
		}
	}
	
	// Update is called once per frame
	void Update (){

		MyWaitingTime ();
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		playerPos = playerTransform.position;
		RandPosition = new Vector3(aX, 0.5f, aZ);
		runAway = new Vector3(-0.73064f, 0.5f, 0.51779f);

		if (playerPos.x >= aX - 4 && playerPos.x <= aX + 4 && Score_Controller.killPower <= 0) {            
			if (playerPos.z >= aZ - 4 && playerPos.z <= aZ + 4) {
				nav.SetDestination (playerPos);
			}
		}
		else if (Score_Controller.killPower > 0) {
			nav.SetDestination (runAway);
		} else {
			nav.SetDestination (RandPosition);
		}
	}

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "Player" && Score_Controller.killPower > 0){
			Score_Controller.killPower--;//Takes kill power-up when it is used
			Score_Controller.scoreCount += 20; //Gives Pacman 20 score points
			transform.position = new Vector3(-0.73064f, 0.5f, 0.51779f);
		}
	}
}