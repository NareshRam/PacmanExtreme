using UnityEngine;
using System.Collections;

public class EnemyKiller : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) { //Making a Collider
		if (other.gameObject.tag == "Player") { //If the Kill Power-up gets hits by Pacman
		  
			//audio.PlayOneShot (audio.clip, 1.0f); //play audio
			Score_Controller.killPower++; // Gives one kill power if player hits the power up
			Destroy(gameObject); // Destroy Kill power-up
		}
	}
}