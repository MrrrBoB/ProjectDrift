using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider))]
public class CompareTagCollision : MonoBehaviour
{
    [SerializeField] private string tagToCompare;
    public UnityEvent collisionEvent;

    private void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.CompareTag(tagToCompare))
            collisionEvent.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCompare))
            collisionEvent.Invoke();
    }
}
