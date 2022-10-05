using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MonoEventsBehavior : MonoBehaviour
{
    public UnityEvent startEvent, collisionEvent, triggerEnterEvent, destroyEvent, disableEvent, quitEvent, tapEvent;
   
    void Start()
    {
        startEvent.Invoke();
    }

    public void OnCollisionEnter(Collision other)
    {
        collisionEvent.Invoke();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnApplicationQuit()
    {
        quitEvent.Invoke();
    }

    private void OnDestroy()
    {
        destroyEvent.Invoke();
    }

    private void OnDisable()
    {
        disableEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        collisionEvent.Invoke();
    }

    public void OnMouseDown()
    {
        tapEvent.Invoke();
    }
}
