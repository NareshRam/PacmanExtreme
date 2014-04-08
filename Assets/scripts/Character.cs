using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0, 0, 0);
		

		if(Input.GetKey(KeyCode.UpArrow)){
			transform.position += new Vector3(-0.2f, 0, 0); //when up arrow is pressed Pacman will move left
				
			}
			
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.position += new Vector3(0.2f, 0, 0); //when down arrow is pressed Pacman will move right
			//gameObject.transform.Rotate(0, 180, 0);
			}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += new Vector3(0, 0, -0.2f); //when left arrow is pressed Pacman will move left
			//gameObject.transform.Rotate(0, -90, 0);

			}
			
			if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += new Vector3(0, 0, 0.2f); //when right arrow is pressed Pacman will move right
			//gameObject.transform.Rotate(0, 90, 0);
			}
		}
	}
