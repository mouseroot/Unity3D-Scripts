using UnityEngine;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour {

    public List<GameObject> checkpoints = new List<GameObject>();
    public bool allCheckpointsActivated = false;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        int totalCheckpoints = checkpoints.Count;
        int activatedCheckpoints = 0;
        foreach (GameObject checkpoint in checkpoints)
        {
            if (checkpoint.GetComponent<CheckpointScript>().checkpointActivated)
            {
                activatedCheckpoints++;
            }
        }
        if (activatedCheckpoints == totalCheckpoints)
        {
            allCheckpointsActivated = true;
        }
	}
}
