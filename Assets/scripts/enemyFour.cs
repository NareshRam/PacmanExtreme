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
	
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.cyan; //drawing the object cyan
		nav = GetComponent<NavMeshAgent>();
		StartCoroutine(MyWaitingTime());
		
	}

	IEnumerator MyWaitingTime()
	{
		while(timerLoop){

			fX = Random.Range(0, -28);
			fZ = Random.Range(0, 28);
			yield return new WaitForSeconds (Random.Range (10, 30)); //The time before the cyan ghost gets a new random position

			fX = Random.Range(0, 27);
			fZ = Random.Range(, position.z + 3);
			yield return new WaitForSeconds (Random.Range (10, 30));

			fX = Random.Range(position.x - 3, position.x + 3);
			fZ = Random.Range(position.z - 3, position.z + 3);
			yield return new WaitForSeconds (Random.Range (10, 30));

			fX = Random.Range(position.x - 10, position.x + 10);
			fZ = Random.Range(position.z - 10, position.z + 10);
			yield return new WaitForSeconds (Random.Range (10, 30));
			
		}
	}
	
	// Update is called once per frame
	void Update (){

		MyWaitingTime ();
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		position = playerTransform.position;
		RandPosition = new Vector3(fX, 0.5f, fZ);
		nav.SetDestination (RandPosition);
	}
}