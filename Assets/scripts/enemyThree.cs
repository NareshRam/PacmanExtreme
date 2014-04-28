﻿using UnityEngine;
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
	Vector3 position;
	Vector3 RandPosition;
	
	// Use this for initialization
	void Start () {

		gameObject.renderer.material.color = Color.magenta; //setting the values for the color pink
		nav = GetComponent<NavMeshAgent>();
		StartCoroutine(MyWaitingTime());
	}

	IEnumerator MyWaitingTime()
	{
		while(timerLoop){
			aX = Random.Range(position.x - 6, position.x + 6);
			aZ = Random.Range(position.z - 6, position.z + 6);
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

	}
}