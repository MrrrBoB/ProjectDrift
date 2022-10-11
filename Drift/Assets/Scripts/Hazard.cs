using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private Material hazardMaterial;

    public UnityEvent playerHitEvent;

    private void Awake()
    {
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().material = hazardMaterial;
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHitEvent.Invoke();
            Debug.Log("Ouch!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
