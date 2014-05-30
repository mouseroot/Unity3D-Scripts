using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
	// Moves the bullet forward
	//
	// This script can be replaced without breaking the 
	// object pooling mechanism

	public float speed = 20f;
	void Update(){
		transform.position = new Vector3(0f,0f,transform.position.z+speed*Time.deltaTime);
	}
}
