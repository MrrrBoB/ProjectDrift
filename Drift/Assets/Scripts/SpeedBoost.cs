using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedBoost : MonoBehaviour
{
    // Start is called before the first frame update
    private Coroutine boostSession;

    public UnityEvent startBoostEvent, endBoostEvent;
    public float boostDuration;
    private WaitForSeconds wfs;
    void Start()
    {
        wfs = new WaitForSeconds(boostDuration);
    }

    public void StartBoost()
    {
        if(boostSession!=null)
            StopCoroutine(boostSession);
        boostSession = StartCoroutine(BoostRoutine());
    }
    public IEnumerator BoostRoutine()
    {
        startBoostEvent.Invoke();
        yield return wfs;
        endBoostEvent.Invoke();
    }
}
