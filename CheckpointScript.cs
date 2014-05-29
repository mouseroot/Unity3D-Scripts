using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class CheckpointScript : MonoBehaviour {
    public bool checkpointActivated = false;

    public void OnTriggerEnter(Collider other)
    {
        checkpointActivated = true;
    }
}
