using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[Serializable]
public class PathNode
{
    public string nodeName;
    public Vector3 pathPosition;
    public float delayTime = 0.1f;
}

public class InstantPathMovement : MonoBehaviour {

    public float startTimer;
    public bool lockObjectToPath = true;
    public bool playOnce = true;

    
    public PathNode[] pathNodes;
    private Vector3 originalPosition;
    private int currentPathIndex = 0;


	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        Invoke("nextNode", startTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextNode()
    {
        Vector3 position;
        float transitionTimer;
        if (currentPathIndex > pathNodes.Length - 1)
        {
            if (playOnce)
            {
                currentPathIndex = pathNodes.Length - 1;
            }
            else
            {
                currentPathIndex = 0;
            }
        }
        position = pathNodes[currentPathIndex].pathPosition;
        transitionTimer = pathNodes[currentPathIndex].delayTime;
        transform.position = position;
        currentPathIndex++;
        Invoke("nextNode", transitionTimer);
    }


    public void OnDrawGizmosSelected()
    {
        if (lockObjectToPath && Application.isEditor && Application.isPlaying == false)
        {
            transform.position = pathNodes[0].pathPosition;
        }
        for (int i = 0; i < pathNodes.Length;i++ )
        {
            //If first node
            if (i == 0)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(pathNodes[0].pathPosition, 0.06f);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(pathNodes[0].pathPosition, pathNodes[i].pathPosition);
                Handles.color = Color.red;
                if (pathNodes[i].nodeName == null || pathNodes[i].nodeName == "")
                {
                    Handles.Label(pathNodes[0].pathPosition, "Node " + i + "(" + pathNodes[0].delayTime + "s)");
                }
                else
                {
                    Handles.Label(pathNodes[0].pathPosition, pathNodes[i].nodeName + " (" + pathNodes[0].delayTime + "s)");
                }
                
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

                Gizmos.DrawSphere(pathNodes[i].pathPosition, 0.05f);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(pathNodes[i - 1].pathPosition, pathNodes[i].pathPosition);
                if (pathNodes[i].nodeName == null || pathNodes[i].nodeName == "")
                {
                    Handles.Label(pathNodes[i].pathPosition, "Node " + i + "(" + pathNodes[i].delayTime + "s)");
                }
                else
                {
                    Handles.Label(pathNodes[i].pathPosition, pathNodes[i].nodeName + " (" + pathNodes[i].delayTime + "s)");
                }
            }
            
        }
    }
}
