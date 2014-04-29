using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject target; // Acquires Pacman
	Vector3 offset; //Vector used for coordinates
	
	void Start() {
		offset = target.transform.position - transform.position; // Sets a range between the camera and Pacman
	}
	
	void LateUpdate() {
		
		float desiredAngle = target.transform.eulerAngles.y; // How much the camera tilts
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0); // Makes the camera tilt downwards
		transform.position = target.transform.position - (rotation * offset); // Updates the camera position when Pacman rotates
		transform.LookAt(target.transform); // Makes sure Pacman is always in sight
	}
}