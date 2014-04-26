using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Pacman"){
			Destroy (gameObject); //destroying object immediatly after
			Application.LoadLevel ("gameover");
		}
	}
}