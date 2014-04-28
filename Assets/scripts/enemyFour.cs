using UnityEngine;
using System.Collections;

//enemy #3, ambusher AI
public class enemyFour : MonoBehaviour {
	
	bool timerLoop = true;
	
	
	private NavMeshAgent nav;
	GameObject player;
	private Transform playerTransform;
	private float fX;
	private float fZ;
	
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
		gameObject.renderer.material.color = Color.cyan; //drawing the object cyan
		nav = GetComponent<NavMeshAgent>();
		
		StartCoroutine(MyWaitingTime());
		
	}
	IEnumerator MyWaitingTime()
	{
		while(timerLoop){
			fX = Random.Range(position.x - 10, position.x + 10);
			fZ = Random.Range(position.z - 10, position.z + 10);
			//The time before it resets back to its original position
			yield return new WaitForSeconds (5.0f);
			
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