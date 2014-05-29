using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class UrlButton : MonoBehaviour {

    public string URL;
	
	// Update is called once per frame
	void OnMouseUpAsButton() {
        Application.OpenURL(URL);
	}
}
