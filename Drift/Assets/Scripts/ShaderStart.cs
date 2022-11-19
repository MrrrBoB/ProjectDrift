using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShaderStart : MonoBehaviour
{
    private Material mat;
    private List<Material> matList = new List<Material>();
    private void Start()
    {
        matList = GetComponent<MeshRenderer>().materials.ToList();
        foreach (Material mat in matList)
        {
            mat.SetFloat("_MaterialTime", Time.time);
        }
    }
}
