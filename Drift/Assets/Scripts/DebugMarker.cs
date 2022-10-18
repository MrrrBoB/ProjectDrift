using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMarker : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up, Color.red, 1f);
    }
}
