using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad DDLinstance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
            
        if (DDLinstance == null)
            DDLinstance = this;
        else
        {
            Destroy(gameObject);
        }
    }
}
