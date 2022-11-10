using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedStartEvent : MonoBehaviour
{
    public UnityEvent delayedEvent;
    public float delay;

    private void Start()
    {
        StartCoroutine(StartCountDown());
    }

    public IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(delay);
        delayedEvent.Invoke();
        Debug.Log("Delayedevent");
    }
}
