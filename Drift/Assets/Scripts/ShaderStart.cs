using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderStart : MonoBehaviour
{
    private Material mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetFloat("_MaterialTime", Time.time);
    }
}
