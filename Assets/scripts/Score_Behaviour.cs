﻿using UnityEngine;
using System.Collections;

public class Score_Behaviour : MonoBehaviour {

	public float lifetime = 0.2f; //timer 0.2 seconds
	void OnTriggerEnter(Collider other) { //Making a Collider
		if (other.gameObject.tag == "Player") { //If the balls gets hit by Pacman
			audio.PlayOneShot (audio.clip, 1.0f); //play audio (Blop sound)
			Score_Controller.scoreCount++; // One point is added to the score

			Destroy (gameObject, lifetime); //Destroy the ball within 0.2sec when player hits it
		}
	}
}