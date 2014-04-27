using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	private NavMeshAgent nav;
	
	GameObject player;
	public Transform playerTransform;
	
	//variables for emergency back-up ai
	//	public float speed;
	//	public float rotationSpeed;
	//	public Transform player;
	//	public Transform myTransform;
	
	//get player position
	Vector3 position;
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update (){
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		position = playerTransform.position;
		nav.SetDestination (position);
		
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