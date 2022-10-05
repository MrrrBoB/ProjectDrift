using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField]
    private float currentCharge;
    public float chargeLoss;
    public float maxCharge;
    public float chargeLossPerTick;
    private WaitForSeconds wfs;
    private Coroutine countDown;
    public bool pauseDeplete;
    
    void Start()
    {
        wfs = new WaitForSeconds(.5f);
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
            currentCharge -= chargeLossPerTick;
        }
        
    }

    public void AddCharge(float val)
    {
        currentCharge += val;
        if (currentCharge > maxCharge)
            currentCharge = maxCharge;
    }
}
