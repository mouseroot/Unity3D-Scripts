using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(InstantPathMovement))]
public class InstantPathMovementEditor : Editor {

    private InstantPathMovement iPathMovement;

    public override void OnInspectorGUI()
    {
        iPathMovement = (InstantPathMovement)target;
        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        foreach (PathNode node in iPathMovement.pathNodes)
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
