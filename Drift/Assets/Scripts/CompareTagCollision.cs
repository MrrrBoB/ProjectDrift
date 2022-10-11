using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompareTagCollision : MonoBehaviour
{
    [SerializeField] private string tagToCompare;
    public UnityEvent collisionEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(tagToCompare))
            collisionEvent.Invoke();
    }
}
