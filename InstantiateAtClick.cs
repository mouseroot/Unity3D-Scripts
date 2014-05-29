using UnityEngine;
using System.Collections;

public class InstantiateAtClick : MonoBehaviour {

    private Ray ray;
    private Vector3 origin;

    public GameObject objectToCreate;
    public int zIndex = 0;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            origin = ray.origin;
            origin.z = zIndex;
            ray.origin = origin;
            Instantiate(objectToCreate, origin, transform.rotation);
        }
	}
}
