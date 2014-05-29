using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor {

    private bool showProperties = true;
    private Object newObject;
    private GameManager gameManager;
    private GameObject toBeRemoved;

    public void OnSceneGUI()
    {
        Handles.Label(gameManager.transform.position - new Vector3(0,0.11f,0f), "Game Manager");
        Handles.color = Color.green;
        Handles.CubeCap(0, gameManager.transform.position, Quaternion.identity, 0.15f);
        foreach (GameObject gameObj in gameManager.gameObjects)
        {
            gameObj.transform.position = Handles.FreeMoveHandle(gameObj.transform.position, Quaternion.identity,0.3f,Vector3.zero,Handles.DrawRectangle);
            Handles.color = Color.white;
            Handles.Label(gameObj.transform.position - new Vector3(0,0.35f,0f), gameObj.transform.name);
            Handles.DrawLine(gameManager.transform.position,gameObj.transform.position);
        }
    }

    public override void OnInspectorGUI()
    {
        gameManager = (GameManager)target;
        EditorGUILayout.LabelField("Game Manager");
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        newObject = EditorGUILayout.ObjectField(newObject, typeof(Object));
        if (GUILayout.Button("Add"))
        {
            gameManager.gameObjects.Add((GameObject)newObject);
            newObject = null;
        }
        EditorGUILayout.EndHorizontal();

        showProperties = EditorGUILayout.Foldout(showProperties, "Managed Properties");
        if (showProperties)
        {
            foreach (GameObject gameObj in gameManager.gameObjects)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(gameObj.transform.name);
                if (GUILayout.Button("Remove"))
                {
                    toBeRemoved = gameObj;
                }
                EditorGUILayout.EndHorizontal();
            }
            gameManager.gameObjects.Remove(toBeRemoved);
            toBeRemoved = null;
        }
    }


}
