using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
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
    public bool pauseDeplete;

    public UnityEvent chargeDepletedEvent;
    
    void Start()
    {
        wfs = new WaitForSeconds(.1f);
        currentCharge = maxCharge;
        sliderBar.maxValue = maxCharge;
        sliderBar.value = currentCharge;
        beginBatteryDrain();
    }

    // Update is called once per frame
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
    

    private void StopDrain()
    {
        StopCoroutine(countDown);
    }
    
}
