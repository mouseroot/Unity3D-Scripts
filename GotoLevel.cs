using UnityEngine;
using System.Collections;

public class GotoLevel : MonoBehaviour {

    public string levelName;

    public enum TriggerCondition
    {
        Return,
        Click
    }

    public TriggerCondition changeOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (changeOn == TriggerCondition.Return)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Application.LoadLevel(levelName);
            }
        }
        else if (changeOn == TriggerCondition.Click)
        {
            if (Input.GetMouseButton(0))
            {
                Application.LoadLevel(levelName);
            }
        }
	}
}
