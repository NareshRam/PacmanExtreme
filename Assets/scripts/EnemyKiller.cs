using UnityEngine;
using System.Collections;

public class EnemyKiller : MonoBehaviour {







	void OnTriggerEnter(Collider other) { //Making a Collider
		if (other.gameObject.tag == "Player") { //If the Kill Power-up gets hits by Pacman
		  


			Score_Controller.killPower++; // Gives one kill power if player hits the power up
			Destroy(gameObject);
//			audio.PlayOneShot (audio.clip, 1.0f);
			// Destroy Kill power-up
//						audio.PlayOneShot (audio.clip, 1.0f); //play audio
		}
	}
}