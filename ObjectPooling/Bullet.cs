using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float lifetime = 3;


	// Deactivates the object after "lifetime" seconds
	void OnEnable(){ // Note: OnEnable 
		Invoke("deactivate",lifetime);
	}

	void deactivate(){
		this.gameObject.SetActive(false);
	}
}
