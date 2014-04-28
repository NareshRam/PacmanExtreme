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
		gameObject.renderer.material.color = new Color (3.0f, 1.0f, 1.0f); //setting the values for the color pink
		nav = GetComponent<NavMeshAgent>();
		
		StartCoroutine(MyWaitingTime());
		
	}
	IEnumerator MyWaitingTime()
	{
		while(timerLoop){
			aX = Random.Range(position.x - 5, position.x + 5);
			aZ = Random.Range(position.z - 5, position.z + 5);
			//The time before it resets back to its original position
			yield return new WaitForSeconds (2.0f);
			
		}
	}
	
	// Update is called once per frame
	void Update (){
		MyWaitingTime ();
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		position = playerTransform.position;
		RandPosition = new Vector3(aX, 0.5f, aZ);
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