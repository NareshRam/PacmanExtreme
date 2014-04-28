using UnityEngine;
using System.Collections;

//enemy #4, stupid AI
public class enemyTwo : MonoBehaviour {

	bool timerLoop = true;


	private NavMeshAgent nav;
	GameObject player;
	public Transform playerTransform;
	public float randX;
	public float randZ;
	
	//variables for emergency back-up ai
	//	public float speed;
	//	public float rotationSpeed;
	//	public Transform player;
	//	public Transform myTransform;
	
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
			//The time before it resets back to its original position
			yield return new WaitForSeconds (20.0f);

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
		
		//emergency back-up ai - Chases directly after pacman, doesnt care about walls
		//		player = GameObject.FindWithTag ("Player").transform;
		//		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
		//		
		//		myTransform.position += myTransform.forward * speed * Time.deltaTime;
		
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Pacman"){
			//			Destroy (gameObject); //destroying object immediatly after
			//			Application.LoadLevel ("gameover");
			
			
			
			
		}
	}
}