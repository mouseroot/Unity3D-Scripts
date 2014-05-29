using UnityEngine;
using UnityEditor;
using System.Collections;

[CanEditMultipleObjects]
[CustomEditor(typeof(CheckpointManager))]
public class CheckpointManagerEditor : Editor {

    private CheckpointManager checkpointManager;

    public override void OnInspectorGUI()
    {
        checkpointManager = (CheckpointManager)target;

        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        Handles.Label(checkpointManager.transform.position, "Checkpoint Manager");
        foreach (GameObject checkpoint in checkpointManager.checkpoints)
        {
            checkpoint.transform.position = Handles.FreeMoveHandle(checkpoint.transform.position, Quaternion.identity, 0.4f, Vector3.zero, Handles.DrawRectangle);
            Handles.Label(checkpoint.transform.position - new Vector3(0, 0.45f, 0f), checkpoint.transform.name);
            Handles.DrawLine(checkpointManager.transform.position, checkpoint.transform.position);
        }
    }
	
}
