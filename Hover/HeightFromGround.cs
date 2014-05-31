using UnityEngine;
using System.Collections;

public class HeightFromGround : MonoBehaviour {
	public LayerMask ground;
	void Awake(){
		if(ground == null)
			ground = LayerMask.NameToLayer("Ground");
	}
	public float getHeight(){
		float distanceToGround = -1;
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit,Mathf.Infinity,ground))
			distanceToGround = hit.distance;
		return distanceToGround;
	}
}
