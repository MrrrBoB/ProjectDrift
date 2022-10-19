using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountDownSimple : MonoBehaviour
{
    private Coroutine countDown;
    public float timer;
    private WaitForSeconds wfs;
    public UnityEvent expireEvent;
    
    // Start is called before the first frame update
    void Awake()
    {
        wfs = new WaitForSeconds(timer);
    }

    public void StartTimer()
    {
        countDown = StartCoroutine(Routine());
    }
    // Update is called once per frame
    private IEnumerator Routine()
    {
        yield return wfs;
        expireEvent.Invoke();
        //Debug.Log(gameObject+" countdown expired");
    }
}
