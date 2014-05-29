using UnityEngine;
using UnityEditor;
using System.Collections;

public class MovetoPoint : MonoBehaviour {

    public Vector3 point;
    public float duration;
    public enum MoveType
    {
        EaseIn,
        EaseOut,
        Instant

    }
    public MoveType moveType;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveType == MoveType.EaseIn)
        {
            transform.position = Vector3.Lerp(transform.position, point, (Time.time - startTime) / duration);
        }
        else if (moveType == MoveType.EaseOut)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, (Time.time - startTime) / duration);
        }
        else if (moveType == MoveType.Instant)
        {
            transform.position = point;
        }
	}

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, point);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.06f);
        Handles.Label(point, " " + moveType.ToString() + "(" + duration + "s)");


    }
}
