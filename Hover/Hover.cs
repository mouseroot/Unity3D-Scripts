using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (HeightFromGround))]

public class Hover : MonoBehaviour {

	public float hoverHeight = 10f;
	public float acceleration = 10f;
	public float drag = .5f;

	private HeightFromGround height;
	private Rigidbody rigidbody;

	void Awake(){
		height = this.gameObject.GetComponent<HeightFromGround>();
		rigidbody = this.gameObject.GetComponent<Rigidbody>();
		rigidbody.drag = drag;
	}

	void FixedUpdate(){
		float distanceFromGround = height.getHeight();
		float magnitude;
		if(hoverHeight>distanceFromGround) {magnitude = (9.8f*rigidbody.mass) + acceleration;}
		else {magnitude = (9.8f*rigidbody.mass) - acceleration;}
		//rigidbody.AddRelativeForce(Vector3.up*(hoverHeight-distanceFromGround+(9.8f*rigidbody.mass)));	
		rigidbody.AddRelativeForce(Vector3.up*magnitude);
	}
}