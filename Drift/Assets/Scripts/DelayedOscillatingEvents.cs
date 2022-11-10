using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DelayedOscillatingEvents : MonoBehaviour
{
    [SerializeField] private bool isDelayed, isRandomDelay;
    [SerializeField] private float oscillationFrequency, maximumDelay;
    private float startDelay;
    private Coroutine oRoutine;
    public UnityEvent eventA, eventB;
    private WaitForSeconds wfs;
    public bool isRunning;
    

    private void Awake()
    {
        startDelay = isRandomDelay ? Random.Range(0, maximumDelay) : maximumDelay;
        wfs = new WaitForSeconds(oscillationFrequency);
    }

    private void Start()
    {
        isRunning = true;
        oRoutine = StartCoroutine(OscillationCoroutine());
    }

    private IEnumerator OscillationCoroutine()
    {
        Debug.Log("started oscillating");
        if(isDelayed)
            yield return new WaitForSeconds(startDelay);
        while (isRunning)
        {
            eventA.Invoke();
            yield return wfs;
            eventB.Invoke();
            yield return wfs;
        }
        //Debug.Log("RoutineEnded");
    }

    public void RestartRoutine()
    {
        if(oRoutine!=null)
            StopCoroutine(oRoutine);
        oRoutine = StartCoroutine(OscillationCoroutine());
    }
}
