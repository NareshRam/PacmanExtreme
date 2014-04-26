using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float rotSpeed = 150.0f;
	public Transform exp;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (new Vector3(0, rotSpeed, 0) * Time.deltaTime);
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Pacman"){
			//Instantiate(exp, transform.position, Quaternion.identity); //transforming the object when hit by pacman (this script is added to all obstacles)
			Destroy (gameObject); //destroying object immediatly after
			Application.LoadLevel ("gameover");
		}
	}
}