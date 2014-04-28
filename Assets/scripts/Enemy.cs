using UnityEngine;
using System.Collections;

//enemy #1 the Chaser
public class Enemy : MonoBehaviour {
	
	private NavMeshAgent nav;
	
	GameObject player;
	private Transform playerTransform;
	
	//get player position
	Vector3 position;
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		gameObject.renderer.material.color = Color.red; //drawing the object red
	}
	
	// Update is called once per frame
	void Update (){
		player = GameObject.FindWithTag ("Player");
		playerTransform = player.transform;
		position = playerTransform.position;
		nav.SetDestination (position);
	}
}