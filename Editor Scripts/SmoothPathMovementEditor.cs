using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]

[CustomEditor(typeof(SmoothPathMovement))]
public class SmoothPathMovementEditor : Editor {

    private SmoothPathMovement sPathMovement;
    private GUIStyle style;

    public override void OnInspectorGUI()
    {
        sPathMovement = (SmoothPathMovement)target;
        base.OnInspectorGUI();
    }


    public void OnSceneGUI()
    {
        style = new GUIStyle();
        Handles.BeginGUI();  
 
        foreach (SmoothPathNode node in sPathMovement.pathNodes)
        {
            style.normal.textColor = node.textColor;
            node.pathPosition = Handles.FreeMoveHandle(node.pathPosition, Quaternion.identity, 0.2f, Vector3.zero, Handles.RectangleCap);
            Vector2 pos2D = HandleUtility.WorldToGUIPoint(node.pathPosition);  
            Handles.Label(node.pathPosition, node.nodeName, style);
        }
        Handles.EndGUI();        
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
