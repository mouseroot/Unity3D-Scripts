using UnityEngine;
using System.Collections;

public class KillOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		int loadedLevel = Application.loadedLevel;
		Application.LoadLevel(loadedLevel);
	}
}
