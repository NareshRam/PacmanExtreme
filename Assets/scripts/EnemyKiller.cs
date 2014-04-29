using UnityEngine;
using System.Collections;

public class EnemyKiller : MonoBehaviour {

	void OnTriggerEnter(Collider other) { //Making a Collider
		if (other.gameObject.tag == "Player") { //If the Kill Power-up gets hit by Pacman

			Score_Controller.killPower++; // Gives the "killPower" buff 
			Destroy(gameObject); //And destroys the buff
		}
	}
}