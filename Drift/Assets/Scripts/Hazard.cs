using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider))]
public class Hazard : MonoBehaviour
{
    [SerializeField]
    private Material hazardMaterial;
    [SerializeField]
    private GameAction respondAction;
    private Material mat;

    private void Awake()
    {
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().material = hazardMaterial;
        }
    }

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetFloat("_MaterialTime", Time.time);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            respondAction.RaiseAction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respondAction.RaiseAction();
        }
    }
}
