using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[Serializable]
public class Flag
{
    public string flagName;
    public bool flagValue = false;
} 

public class FlagManager : MonoBehaviour {

    public Flag[] gameFlags;

    public void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.Label(transform.position,"FlagManager (" + gameFlags.Length + " Flags)");
    }

    public void createFlag(string name,bool setValue)
    {
        Flag newFlag = new Flag();
        newFlag.flagName = name;
        newFlag.flagValue = setValue;
        gameFlags[gameFlags.Length] = newFlag;

    }

    public bool getFlag(string name)
    {
        foreach(Flag flag in gameFlags)
        {
            if(flag.flagName == name)
            {
                return flag.flagValue;
            }
        }
        return false;
    }

    public void setFlag(string name,bool val)
    {
        foreach(Flag flag in gameFlags)
        {
            if(flag.flagName == name)
            {
                flag.flagValue = val;
            }
        }
    }
}
