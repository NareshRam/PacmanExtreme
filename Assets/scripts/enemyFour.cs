using UnityEngine;
using System.Collections;

//enemy #3, fickle AI
public class enemyFour : MonoBehaviour {
	
	bool timerLoop = true;
	private NavMeshAgent nav;
	GameObject player;
	private Transform playerTransform;

	private float fX;
	private float fZ;

	//get player position
	Vector3 position;
	Vector3 RandPosition;
	Vector3 runAway;
	
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.cyan; //drawing the object cyan
		nav = GetComponent<NavMeshAgent>();
		StartCoroutine(MyWaitingTime());
		
	}

	IEnumerator MyWaitingTime() // enum function MyWaitingTime is constantly called in Update, the while loop loops indefinetely, relatively randomizing destinations of the AI
	{
		while(timerLoop){ 

			fX = Random.Range(0, -28); //Random coordinates in the Top left Corner
			fZ = Random.Range(0, 28);
			yield return new WaitForSeconds (Random.Range (5, 20)); //The time before the cyan ghost gets a new random position, between 5 and 20 seconds

			fX = Random.Range(0, 27); //bottom right corner
			fZ = Random.Range(0, -26);
			yield return new WaitForSeconds (Random.Range (5, 20));

			fX = Random.Range(0, 27); //Top right corner
			fZ = Random.Range(0, 28);
			yield return new WaitForSeconds (Random.Range (5, 20));

			fX = Random.Range(0, -27); //bottom left corner
			fZ = Random.Range(0, -25);
			yield return new WaitForSeconds (Random.Range (5, 20));
		}
	}
	
	// Update is called once per frame
	void Update (){

		MyWaitingTime ();
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		position = playerTransform.position;
		RandPosition = new Vector3(fX, 0.5f, fZ);
		runAway = new Vector3(-1.55061f, 0.5f, -0.4118f);

		if (position.x >= fX - 10 && position.x <= fX + 10 && Score_Controller.killPower <= 0) {            
			if (position.z >= fZ - 10 && position.z <= fZ + 10) {
				nav.SetDestination (position);
			}
		}
		else if (Score_Controller.killPower > 0) {
			nav.SetDestination (runAway);
		} else {
			nav.SetDestination (RandPosition);
		}
	}
}