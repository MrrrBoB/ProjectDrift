using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class SwapColliders : MonoBehaviour
{
    public Collider col1;

    public Collider col2;
    
    // Start is called before the first frame update
    void Start()
    {
        col1.enabled = true;
        col2.enabled = false;
    }

    public void SwapCols()
    {
        col1.enabled = !col1.enabled;
        col2.enabled = !col2.enabled;
    }
    
}
