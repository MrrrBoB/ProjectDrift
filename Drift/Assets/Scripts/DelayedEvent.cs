using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour
{
    private Coroutine currentRoutine;
    public float delayCount;
    private WaitForSeconds wfs;
    public UnityEvent delayedEvent;

    private void Start()
    {
        wfs = new WaitForSeconds(delayCount);
    }

    public void StartCountDown()
    {
        if (currentRoutine != null) //reset The coroutine
            StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(DelayedRoutine());
    }

    private IEnumerator DelayedRoutine()
    {
        yield return wfs;
        delayedEvent.Invoke();
    }
        
}
