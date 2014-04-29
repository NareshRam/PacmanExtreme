using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Quests/SpinningSymbol")]
public class Spin : MonoBehaviour {


		private void Update(){
			transform.Rotate(0,100*Time.deltaTime,0); // Rotates an object
		}
	
}
