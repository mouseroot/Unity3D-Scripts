using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class TriggerAreaLookAtTag : MonoBehaviour {

    public string trackingTag;
    private bool isTracking = false;
    private GameObject trackingObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isTracking && trackingObject != null)
        {
            // (Yes this is from the LookAtMouse script)
            //Look at trackingObject
            Vector3 position = trackingObject.transform.position;

            //Force 0 on the Z, since it doesnt matter in 2D
            position.z = 0;

            //Get a relative position
            Vector3 lookPosition = position - transform.position;

            //Do some trig to get the corret angle (Found this formula online, long long ago so no source, but thx whoever came up with this)
            float angle = Mathf.Atan2(lookPosition.x, lookPosition.y) * -Mathf.Rad2Deg;

            //Set the sprites rotation to the angle
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
	}

    //When an object enters the area
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == trackingTag)
        {
            print("Tracking object " + col.gameObject.name);
            isTracking = true;
            trackingObject = col.gameObject;
        }
    }

    //When an object leaves the area
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == trackingTag)
        {
            print("No longer tracking " + col.gameObject.name);
            isTracking = false;
            trackingObject = null;
        }
    }
}
