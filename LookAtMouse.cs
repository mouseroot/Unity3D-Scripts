using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour
{
    private float angle;
    private Vector3 mousePosition;
    private Vector3 lookPosition;
    private Ray ray;

    public void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        lookPosition = ray.origin;
        lookPosition = lookPosition - transform.position;
        angle = Mathf.Atan2(lookPosition.x, lookPosition.y) * -Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}