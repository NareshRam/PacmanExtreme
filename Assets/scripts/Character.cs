using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float movementSpeed;
	public float turnSpeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);
	}

	void OnCollisionEnter(Collision other){ //collision to detect if pacman hits a ghost, he "dies"
		if(other.gameObject.name == "GhostCaps"){
			Score_Controller.lifeCount--;
			transform.position = new Vector3(0.0f, 0.5f, -14.0f);
			if( Score_Controller.lifeCount < 0){

				Application.LoadLevel ("gameover");
			}
		}
	}
}