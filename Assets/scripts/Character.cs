using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float movementSpeed = 10;
	public float turnSpeed = 10;
	//public float playerSpeed = 10.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.Euler(0, 0, 0);

		float horizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);
		
		//transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * playerSpeed * Time.deltaTime); // left / right
		//transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime); // forward / backwards

//		if(Input.GetKey(KeyCode.UpArrow)){
//			transform.position += new Vector3(-0.2f, 0, 0); //when up arrow is pressed Pacman will move left
//		}
//			
//		if(Input.GetKey(KeyCode.DownArrow)){
//			//transform.position += new Vector3(0.2f, 0, 0); //when down arrow is pressed Pacman will move right
//			transform.Rotate(0, 180, 0);
//		}
//
//		if(Input.GetKey(KeyCode.LeftArrow)){
//			//transform.position += new Vector3(0, 0, -0.2f); //when left arrow is pressed Pacman will move left
//			transform.Rotate(0, -90f, 0);
//		}
//			
//		if(Input.GetKey(KeyCode.RightArrow)){
//			//transform.position += new Vector3(0, 0, 0.2f); //when right arrow is pressed Pacman will move right
//			transform.Rotate(0, 90f, 0);
//		}
	}

	void OnCollisionEnter(Collision other){ //collision to detect if pacman hits a ghost, he "dies"
		if(other.gameObject.name == "Ghost"){
		//Instantiate(exp, transform.position, Quaternion.identity); //transforming the object when hit by pacman (this script is added to all obstacles)
		Destroy (gameObject); //destroying object immediatly after
		}
	}
}