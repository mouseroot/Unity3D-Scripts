/*
 *  Script: LookAtMouse
 *  
 *  By: Mouseroot
 *  
 *  Perspective: 2D Only
 *  
 *  Useful for: Topdown shooters, Topdown click to move, Topdown etc etc...
 *  
 *  Description: Attaching this script to a sprite facing up (in 2d thats, exactly what it means)
 *      the sprite will always look at the mouse by rotating at the center (the default)
 *      
 *  Todo: Could add an additional Lerp/Slerp function to create delayed rotation
 */
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
        //Store mouse position
        mousePosition = Input.mousePosition;

        //Force 0 on the Z, since it doesnt matter in 2D
        mousePosition.z = 0;

        //Create a ray
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Store the origin of the ray(essentialy where the mouse is)
        lookPosition = ray.origin;

        //Get a relative position
        lookPosition = lookPosition - transform.position;

        //Do some trig to get the corret angle (Found this formula online, long long ago so no source, but thx whoever came up with this)
        angle = Mathf.Atan2(lookPosition.x, lookPosition.y) * -Mathf.Rad2Deg;

        //Set the sprites rotation to the angle
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
