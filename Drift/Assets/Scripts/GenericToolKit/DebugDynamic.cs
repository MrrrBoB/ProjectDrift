using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDynamic : MonoBehaviour
{
    public string printStatement;

    public void PrintDebug()
    {
        Debug.Log(printStatement);
    }
}
