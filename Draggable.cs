using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Draggable : MonoBehaviour {

    private Ray ray;
    private Vector3 origin;

	public bool lockX = true;
    public bool lockY = true;
    public int zIndex = 0;

    void OnMouseDrag()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        origin = ray.origin;
        origin.z = zIndex;
        if (lockX)
        {
            origin.y = transform.position.y;
        }
        if (lockY)
        {
            origin.x = transform.position.x;
        }
        ray.origin = origin;
        transform.position = ray.origin;
    }
}
