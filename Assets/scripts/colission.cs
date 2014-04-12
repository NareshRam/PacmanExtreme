using UnityEngine;
using System.Collections;

public class colission : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Function for removing a buff when colission occurs
void OnCollisionEnter(Collision other)
{
//buff will be removed on colission
if(other.gameObject.name == "small_pebble")
{
Destroy (gameObject);
}
}
	
}