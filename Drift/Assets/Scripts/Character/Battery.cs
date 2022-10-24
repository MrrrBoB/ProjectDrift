using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    [SerializeField]
    private float currentCharge;
    public float maxCharge;
    public float chargeLossPerTick;
    [SerializeField]
    private Slider sliderBar;
    private WaitForSeconds wfs;
    private Coroutine countDown;
    private bool pauseDeplete;

    public UnityEvent chargeDepletedEvent;
    
    void Start()
    {
        wfs = new WaitForSeconds(.1f);
        currentCharge = maxCharge;
        sliderBar.maxValue = maxCharge;
        sliderBar.value = currentCharge;
        beginBatteryDrain();
    }

    private IEnumerator CountDown()
    {
        currentCharge = maxCharge;
        while (currentCharge > 0)
        {
            while (pauseDeplete)
            {
                yield return null;
            }
            yield return wfs;
            changeCharge(-chargeLossPerTick);
        }
        Debug.Log("Out of battery");
        chargeDepletedEvent.Invoke();
    }

    
    public void AddCharge(float val)
    {
        currentCharge += val;
        if (currentCharge > maxCharge)
            currentCharge = maxCharge;
    }

    private void changeCharge(float val)
    {
        currentCharge += val;
        sliderBar.value = currentCharge;
    }

    public void beginBatteryDrain()
    {
        countDown = StartCoroutine(CountDown());
    }
    

    private void EndDrain()
    {
        StopCoroutine(countDown);
    }

    public void SetActiveDrainStatus(bool active)
    {
        pauseDeplete = !active;
    }

    public void ResetBattery()
    {
        if (countDown != null)
        {
            StopCoroutine(countDown);
        }
        currentCharge = maxCharge;
        sliderBar.value = currentCharge;
        beginBatteryDrain();

    }
}
