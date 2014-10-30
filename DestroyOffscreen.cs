using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (renderer.isVisible == false)
        {
            Destroy(gameObject);
        }
	}
}
