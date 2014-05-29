using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(SmoothPathMovement))]
public class SmoothPathMovementEditor : Editor {

    private SmoothPathMovement sPathMovement;

    public override void OnInspectorGUI()
    {
        sPathMovement = (SmoothPathMovement)target;
        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        foreach (SmoothPathNode node in sPathMovement.pathNodes)
        {
            node.pathPosition = Handles.FreeMoveHandle(node.pathPosition, Quaternion.identity, 0.3f, Vector3.zero, Handles.DrawRectangle);
        }
    }
    Tool LastTool = Tool.None;

    void OnEnable()
    {
        LastTool = Tools.current;
        Tools.current = Tool.None;
    }

    void OnDisable()
    {
        Tools.current = LastTool;
    }

}
