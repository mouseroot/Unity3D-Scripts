using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[Serializable]
public class SmoothPathNode
{
    public string nodeName;
    public Color textColor;
    public Vector3 pathPosition;
    public float transitionDuration;
}

public class SmoothPathMovement : MonoBehaviour {
    public enum PathTransision
    {
        EaseIn,
        EaseOut

    }
    public PathTransision transitionType;
    public SmoothPathNode[] pathNodes;
    public bool lockObjectToPath = true;
    private int currentPathIndex = 0;
    private Vector3 currentPathPosition;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        currentPathPosition = pathNodes[0].pathPosition;
	}
	
	// Update is called once per frame
	void Update () {
      
        if (Vector3.Distance(transform.position, currentPathPosition) > 0.01f)
        {
            if (transitionType == PathTransision.EaseIn)
            {
                transform.position = Vector3.Lerp(transform.position, currentPathPosition, (Time.time - startTime) / pathNodes[currentPathIndex].transitionDuration);
            }
            else if (transitionType == PathTransision.EaseOut)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentPathPosition, (Time.time - startTime) / pathNodes[currentPathIndex].transitionDuration);
            }
        }
        else
        {
            startTime = Time.time;
            currentPathIndex++;
            if (currentPathIndex >= pathNodes.Length)
            {
                currentPathIndex = 0;
            }
            currentPathPosition = pathNodes[currentPathIndex].pathPosition;
        }
        
	}

    void OnDrawGizmosSelected()
    {
        if (Application.isEditor && Application.isPlaying == false && currentPathIndex == 0 && lockObjectToPath)
        {
            transform.position = pathNodes[0].pathPosition;
        }
        for (int i = 0; i < pathNodes.Length; i++)
        {
            //If first node
            if (i == 0)
            {
                Gizmos.color = Color.green;
                //Gizmos.DrawSphere(pathNodes[0].pathPosition, 0.10f);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(pathNodes[0].pathPosition, pathNodes[i].pathPosition);
                Handles.color = Color.red;

            }
            //if node is not the first
            else
            {
                if (i == pathNodes.Length - 1)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.blue;
                }

                Gizmos.DrawSphere(pathNodes[i].pathPosition, 0.10f);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(pathNodes[i - 1].pathPosition, pathNodes[i].pathPosition);
            }

        }
    }

}
