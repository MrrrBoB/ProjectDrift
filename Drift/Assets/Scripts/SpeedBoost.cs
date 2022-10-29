using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpeedBoost : MonoBehaviour
{
    // Start is called before the first frame update
    private Coroutine boostSession, displaySession;

    public UnityEvent startBoostEvent, endBoostEvent;
    public float boostDuration;
    private WaitForSeconds wfs, wfsD;
    public float decayFrequency;
    [SerializeField] private Slider decaySlider;
    void Start()
    {
        wfs = new WaitForSeconds(boostDuration);
        wfsD = new WaitForSeconds(decayFrequency);
        if (decaySlider != null)
        {
            decaySlider.maxValue = boostDuration;
            SetSliderActive(false);
        }
    }

    public void StartBoost()
    {
        if(boostSession!=null)
            StopCoroutine(boostSession);
        boostSession = StartCoroutine(BoostRoutine());
        if(displaySession!=null)
            StopCoroutine(displaySession);
        displaySession = StartCoroutine(BoostDisplayRoutine());
    }
    public IEnumerator BoostRoutine()
    {
        startBoostEvent.Invoke();
        yield return wfs;
        endBoostEvent.Invoke();
    }

    public IEnumerator BoostDisplayRoutine()
    {
        SetSliderActive(true);
        decaySlider.value = decaySlider.maxValue;
        while (decaySlider.enabled)
        {
            yield return wfsD;
            decaySlider.value -= decayFrequency;
            if(decaySlider.value<=0)
                SetSliderActive(false);
        }
    }

    public void SetSliderActive(bool b)
    {
        if (decaySlider != null)
            decaySlider.gameObject.SetActive(b);
    }
}
