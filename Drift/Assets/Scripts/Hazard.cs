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

    private void Awake()
    {
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().material = hazardMaterial;
        }
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
