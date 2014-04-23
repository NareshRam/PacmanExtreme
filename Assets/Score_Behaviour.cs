using UnityEngine;
using System.Collections;

public class Score_Behaviour : MonoBehaviour {

	
	void OnTriggerEnter(Collider other) { //Making a Collider
		Score_Controller.scoreCount++; // Score plus one if player hits the balls

		Destroy (this.gameObject); //Destroy the ball when player hits it

	}
}
	

