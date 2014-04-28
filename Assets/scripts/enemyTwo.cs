using UnityEngine;
using System.Collections;

//enemy #4, stupid AI
public class enemyTwo : MonoBehaviour {

	bool timerLoop = true;
	private NavMeshAgent nav;
	GameObject player;
	private Transform playerTransform;
	private float randX;
	private float randZ;
	
	//get player position
	Vector3 position;
	Vector3 RandPosition;
	
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = new Color (1f, .65f, 0f); //setting the values for the color orange
		nav = GetComponent<NavMeshAgent>();
		StartCoroutine(MyWaitingTime());
	}

	IEnumerator MyWaitingTime()
	{
		while(timerLoop){
			randX = Random.Range(-27.0f, 27.0f);
			randZ = Random.Range(-26.4f, 28.0f);
			yield return new WaitForSeconds (20.0f); //The time before Orange ghost gets a new random position
		}
	}
	
	// Update is called once per frame
	void Update (){
		MyWaitingTime ();
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		position = playerTransform.position;
		RandPosition = new Vector3(randX, 0.5f, randZ);
		nav.SetDestination (RandPosition);
	}
}