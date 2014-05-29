using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlatformerMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpPower;
    public string platformTagString;

    private Rigidbody rBody;
    private bool onGround = false;


	// Use this for initialization
	void Start () {
        rBody = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            onGround = false;
            rBody.AddForce(Vector3.up * (jumpPower * 2));
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.tag == platformTagString)
        {
            onGround = true;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.transform.tag != platformTagString)
        {
            onGround = false;
        }
    }
}
